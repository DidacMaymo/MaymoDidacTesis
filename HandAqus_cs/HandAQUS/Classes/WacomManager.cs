using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using NLog;
using WintabDN;

namespace HandAQUS
{
    internal class WacomManager
    {
        // Define variables for WinTab API
        private CWintabContext _mLogContext;
        private CWintabData _mWtData;
        private readonly Panel _scribblePanel;
        private Graphics _mGraphics;
        private Pen _mPen;
        private Label _label;
        private bool _debug_mode;

        private ulong _mPkTimeLast;

        private Point _mLastPoint = Point.Empty;
        private uint _mMaxPkts = 1; // max num pkts to capture/display at a time
        private const uint QueueSize = 128;
        private uint _numPktsO;

        // This is for get maximal Axes values, to set Gird
        // Default vale for read only mode are Intos5 L maximal values 
        private int _mTabextx = 34815;
        private int _mTabexty = 19758;
        private short _mPressureMax = 6553;

        private int _widthDigitizer;
        private int _heightDigitizer;
        private int _widthMonRes;
        private int _heightMonRes;

        // Prepare logger
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        // Keep captured data as packet List for saving
        public List<WintabPacket> SessionData { get; } = new List<WintabPacket>();

        // save start recording timepoint
        public TimeSpan StartTime;
        public bool StartTimeSet = false;

        // Keep loaded data from file in case to save them
        public List<long[]> _loadedData = new List<long[]>();

        // This constant serve to divide maximal pressure of device  
        // to obtain m_PRESSURE_MAX
        private const byte BulgarConstant = 5;


        // Constructor
        public WacomManager(Panel scribblePanel, Label label)
        {
            _scribblePanel = scribblePanel;
            _label = label;
            _debug_mode = false;
        }

        public void SetDebug(bool status)
        {
            _debug_mode = status;
        }

        public bool GetDebug()
        {
            return _debug_mode;
        }

        public int GetMaxTabletY()
        {
            return _mTabexty;
        }


        private void ClearDisplay()
        {
            // Clear Panel
            _scribblePanel.Invalidate();
            _logger.Info("Scribble panel has been cleared.");

            // Clear sessionData (all packets)          
            SessionData.Clear();
            _loadedData.Clear();
            _logger.Info("The size of session data has been reset. Size = {0}", SessionData.Count);

            //Try to reset the buffer
            if (_mWtData != null)
            {
                _mWtData.FlushDataPackets(QueueSize);
                _mWtData.SetPacketQueueSize(0);
                _mWtData.SetPacketQueueSize(QueueSize);
            }
        }

        private void CloseCurrentContext()
        {
            try
            {
                // First check if context is not null yet
                if (_mLogContext != null)
                {
                    // If is not null close it
                    if (!_mLogContext.Close())
                    {
                        throw new Exception("Can't close the CWintabContext!");
                    }

                    // Now set context and captured data to null
                    CWintabFuncs.WTClose(_mLogContext.HCtx);
                    _mLogContext = null;
                    _mWtData = null;
                }

                _logger.Debug("CWintabContext has been cleared.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, nameof(CloseCurrentContext));
                MessageBox.Show(ex.ToString());
            }
        }

        public void ContinueScribble()
        {
            // re-init scribble graphics.
            _mGraphics = _scribblePanel.CreateGraphics();
            _mGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            _logger.Debug($"Continue scribbling. Data size is: {SessionData.Count}");
            _logger.Debug($"[THREAD] Number of active threads: {Process.GetCurrentProcess().Threads.Count}");
        }

        public void PauseScribble()
        {
            _mGraphics = null;
            _logger.Info($"Scribble has been paused. Data size is: {SessionData.Count}");
        }

        public void StartScribble()
        {
            // Close context and clear panel
            CloseCurrentContext();
            ClearDisplay();

            // Set up to capture 1 packet at a time.
            _mMaxPkts = 1;

            // Init scribble graphics.
            _mGraphics = _scribblePanel.CreateGraphics();
            _mGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            _logger.Debug("Starting scribble");
            _logger.Debug(
                $"Size of Graphics is: dpi_x = {_mGraphics.DpiX}. dpi_y = {_mGraphics.DpiY}, page_scale = {_mGraphics.PageScale}, page_unit = {_mGraphics.PageUnit}");

            // Set pen color
            _mPen = new Pen(Color.Black);
            //m_backPen = new Pen(Color.White);

            // Initialize data capture. Now you should be able to scribble
            InitDataCapture();

            _logger.Debug($"[THREAD] Number of active threads: {Process.GetCurrentProcess().Threads.Count}");
            _logger.Debug($"Packet Queue Size is: {_mWtData.GetPacketQueueSize()}");
        }

        public void StopScribble()
        {
            _logger.Debug("Scribble has been stopped.");
            // Close scribble context.
            CloseCurrentContext();

            // Turn off graphics.
            if (_mGraphics != null)
            {
                _mGraphics = null;
                _logger.Debug("Graphics has been set to null.");
            }

            _logger.Debug($"[THREAD] Number of active threads: {Process.GetCurrentProcess().Threads.Count}");
        }


        private void InitDataCapture(bool ctrlSysCursorI = false)
        {
            try
            {
                _logger.Debug("[InitDataCapture] Data capture Initialization.");

                // Open up a new context with cursor control flag (false by default)
                _logger.Debug($"Opening the new CWintabContext with Cursor Control = {ctrlSysCursorI}");
                _mLogContext = OpenTestDigitizerContext(ctrlSysCursorI);
                _logger.Debug($"m_logContext: {_mLogContext.Status}");

                // If context was not open, return
                if (_mLogContext == null)
                {
                    _logger.Error("[InitDataCapture] The CWintabContext is null. The context has not been opened!");
                    throw new Exception("The context has not been opened");
                }

                // Create a data object and set its WT_PACKET handler. 
                _mWtData = new CWintabData(_mLogContext);
                _mWtData.SetWTPacketEventHandler(MyWTPacketEventHandler);
                if (!_mWtData.SetPacketQueueSize(QueueSize))
                {
                    _logger.Error("Can't setup a queue size");
                }
                //logger.Debug($"wt_Data packet queue size: {m_wtData.GetPacketQueueSize()}");

                // ensure createn/update of StartTime
                StartTimeSet = false;

            }

            catch (Exception ex)
            {
                _logger.Error(ex, "InitDataCapture");
                MessageBox.Show($"InitDataCapture {ex}");
            }
        }

        private CWintabContext OpenTestDigitizerContext(bool ctrlSysCursor = false)
        {
            // Init wintab context variable
            CWintabContext logContext = null;

            try
            {
                // Get the default digitizing context.
                // Default is to receive data events.
                logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);
                logContext.Options |= (uint) ECTXOptionValues.CXO_MGNINSIDE;

                // Set system cursor if caller wants it (if true).
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint) ECTXOptionValues.CXO_SYSTEM;
                }

                // Modify the digitizing region.
                // Set name
                logContext.Name = "WintabDN Event Data Context";
                // Set packet mode to get button status in 0/1.
                logContext.PktMode = 1;
                // Set X,Y origin of the context's input area in the tablet's native coordinates
                logContext.InOrgX = logContext.InOrgY = 0;

                
                // 
                logContext.OutExtX++;

                // Invert the Y axis (This is for Cintiq)
                logContext.OutExtY = -logContext.OutExtY;

                // Get Digitizer Size
                _widthDigitizer = logContext.OutExtX;
                _heightDigitizer = (logContext.OutExtY * -1);

                // Setup monitor resolution 
                _heightMonRes = getTabletScreen().Bounds.Height;
                _widthMonRes = getTabletScreen().Bounds.Width;

                // Open the context, which will also tell Wintab to send data packets.
                logContext.Open();

                _logger.Debug($"logContext: Device number = {logContext.Device}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "OpenTestDigitizerContext");
                MessageBox.Show($"OpenTestDigitizerContext ERROR: {ex}");
            }

            return logContext;
        }


        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Called when Wintab WT_PACKET events are received.
        /// </summary>
        /// <param name="senderI">The EventMessage object sending the report.</param>
        /// <param name="eventArgsI">eventArgsI.Message.WParam contains ID of packet containing the data.</param>   
        private void MyWTPacketEventHandler(object senderI, MessageReceivedEventArgs eventArgsI)
        {
            eventArgsI.Message.ToString();

            try
            {
                // Maximum of processed packet at once have to be 1 and Graphic must be initialized
                if (_mMaxPkts != 1 && _mGraphics == null) return;

                // Use GetDataPackets(number of packets) to read all packets in queue and process then at once
                var packetsToProcess = _mWtData.GetDataPackets(QueueSize, true, ref _numPktsO)?.Where(pkt => pkt.pkContext != null);

                if (packetsToProcess != null)
                {                    
                    if (!StartTimeSet)
                    {
                        StartTime = DateTime.Now.TimeOfDay;
                        _logger.Debug($"Start time set: {StartTime}");
                        StartTimeSet = true;

                    }
                    packetsToProcess = ModifyPackets(packetsToProcess);
                    SessionData.AddRange(packetsToProcess);
                    DrawPoint(packetsToProcess);
                    packetsToProcess.ToList().Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex);
            }
        }

        public IEnumerable<WintabPacket> ModifyPackets(IEnumerable<WintabPacket> packets)
        {
            List<WintabPacket> output = new List<WintabPacket>();

            foreach (var pkt in packets)
            {
                if (pkt.pkButtons > 1 && pkt.pkNormalPressure > 0)
                {
                    // Case when pressure is more than 0, so on surface
                    var packet = pkt;
                    packet.pkButtons = 1;
                    output.Add(packet);
                }

                else if (pkt.pkButtons > 1 && pkt.pkNormalPressure == 0)
                {
                    // Case when pressure is less than 0, so in air
                    var packet = pkt;
                    packet.pkButtons = 0;
                    output.Add(packet);
                }
                else
                {
                    output.Add(pkt);
                }
            }

            return output;
        }

        // Remove first captured in-air data 
        public void RemoveFirstInAirData()
        {
            int CountToFisrtOne = 0;
            for (int i = 0; i < SessionData.Count; i++)
            {
                if (SessionData[i].pkButtons != 0)
                {
                    CountToFisrtOne = i;
                    break;
                }
            }

            // correcting start time
            SessionData.RemoveRange(0, CountToFisrtOne);
            TimeSpan Correction = new TimeSpan(0, 0, 0, 0, (int)SessionData[CountToFisrtOne].pkTime - (int)SessionData[0].pkTime);
            StartTime = StartTime.Add(Correction);
            _logger.Debug($"The number of removed first in air samples is {CountToFisrtOne}. StartTime changed to {StartTime}. {Correction} added to it.");
        }

        // Remove last captured in-air data
        public void RemoveLastInAirData()
        {
            var firstlastZeroPacketIndex = 0;
            var CountToTheEnd = 0;

            for (var i = SessionData.Count - 1; i > 0; i--)
            {
                if (SessionData[i].pkButtons != 0)
                {
                    firstlastZeroPacketIndex = i;
                    CountToTheEnd = SessionData.Count - i;
                    break;
                }
            }

            SessionData.RemoveRange(firstlastZeroPacketIndex, CountToTheEnd);
            _logger.Debug($"The number of removed last in air samples is {CountToTheEnd}.");
        }


        public static bool IsWintabAvailable()
        {
            return CWintabInfo.IsWintabAvailable();
        }

        public static uint GetNumberOfDevices()
        {
            return CWintabInfo.GetNumberOfDevices();
        }

        public static string GetDeviceInfo()
        {
            return CWintabInfo.GetDeviceInfo();
        }
        

        public void SetAxisAndPressureMax()
        {
            _logger.Debug("Device connected: {0}", CWintabInfo.GetDeviceInfo());

            // set axis maximums and pressure maximum 
            _mTabextx = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_X).axMax;
            _mTabexty = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_Y).axMax;
            _mPressureMax = (short) (CWintabInfo.GetMaxPressure() / BulgarConstant);

            _logger.Debug(
                $"Set axis and pressure by device: Tablet X: {_mTabextx}; Tablet Y: {_mTabexty}; Tablet P: {_mPressureMax}");
        }

        public void ReDrawTask()
        {
            // First check for the session data
            if (SessionData.Any())
            {
                // Draw acquired data for current task
                _logger.Info("Re-drawing data from SessionData.");
                _logger.Info($"Session data count: {SessionData.Count}");

                DrawData(SessionData);
            }
            // Next check for the loaded data
            else if ( _loadedData.Any())
            {
                // Draw acquired data loaded from file
                _logger.Info("Re-drawing data loaded from File.");
                _logger.Info($"Loaded data count: {_loadedData.Count}");

                DrawDataFromFile(_loadedData);
            }

            else
            {
                // No data to re-draw
                _logger.Warn("No data to Draw in Session data.");
                _logger.Warn($"Session data count: {SessionData.Count}");
                _logger.Warn("No data to Draw in loaded data.");
                _logger.Warn($"Session data count: {_loadedData.Count}");
            }
        }

        public void DrawData(List<WintabPacket> data)
        {
            try
            {
                // Init scribble graphics.
                // m_graphics = CreateGraphics();
                _mGraphics = _scribblePanel.CreateGraphics();
                _mGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                _mPen ??= new Pen(Color.Black);

                //logger.Debug($"m_graphisc has been assigned: Clip: {m_graphics}");

                // Set last point as Empty
                _mLastPoint = Point.Empty;

                // If Graphics is not null process drawing
                if (_mGraphics != null)
                {
                    // For each point in loaded data 
                    DrawPoint(data);

                    _logger.Info($"Data has been drawn (Size: {data.Count} samples)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"FAILED to get data:{ex}");
            }
        }


        public void DrawDataFromFile(List<long[]> data)
        {
            try
            {
                // Store data to cache in case of redrawing it
                _loadedData = new List<long[]>(data);

                // Init scribble graphics.
                // m_graphics = CreateGraphics();
                _mGraphics = _scribblePanel.CreateGraphics();
                _mGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                _mPen ??= new Pen(Color.Black);

                //logger.Debug($"m_graphisc has been assigned: Clip: {m_graphics}");

                // Set last point as Empty
                _mLastPoint = Point.Empty;

                // If Graphics is not null process drawing
                if (_mGraphics != null)
                {
                    // For each point in loaded data 
                    foreach (var packet in data)
                    {
                        // If packet do not contains all information or pen is in Air-mode then skip
                        if (packet.Length < 7 || packet[3] == 0)
                        {
                            // Set last point as empty
                            _mLastPoint = Point.Empty;
                        }
                        else
                        {
                            DrawPoint(packet);
                        }
                    }

                    _logger.Info($"Data has been drawn (Size: {data.Count} samples)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"FAILED to get data:{ex}");
            }
        }


        private void DrawPoint(IEnumerable<WintabPacket> pkts)
        {
            foreach (var pkt in pkts)
            {
                DrawPoint(pkt);
            }
        }

        private void DrawPoint(long[] pkt)
        {
            // Read axis, time-stamp and pressure
            var pkX = (ushort) pkt[0];
            var pkY = (ushort) pkt[1];
            var pkTime = (ulong) pkt[2];
            var pressure = (uint) pkt[6];

            // Draw a point 
            Draw(pkX, pkY, pkTime, pressure);
        }

        private void DrawPoint(WintabPacket pkt)
        {
            // Read pressure
            var pkX = pkt.pkX;
            var pkY = pkt.pkY;
            var pkTime = pkt.pkTime;
            var pressure = pkt.pkNormalPressure;

            // Draw a point 
            Draw(pkX, pkY, pkTime, pressure, pkt);
        }

        private void Draw(int pkX, int pkY, ulong pkTime, uint pressure, WintabPacket pkt = new WintabPacket())
        {
            //Recompute the points according to the screen (CINTIQ)
            var x = XPointDigitizerToPx(pkX);
            var y = YPointDigitizerToPx(pkY);

            // create point for drawing on panel
            var tabPoint = new Point(x, y);

            // update scribble panel
            _scribblePanel.Update();

            // if last point which was drawn is empty (e.g. first point)
            if (_mLastPoint.Equals(Point.Empty))
            {
                // set new point as a last one, included time-stamp
                _mLastPoint = tabPoint;
                _mPkTimeLast = pkTime;
            }

            // set pen width,
            _mPen.Width = (float) (pressure / (double) _mPressureMax);

            // if pressure is bigger than 0 (on-surface movement) draw a point (line between points)
            if (pressure > 0)
            {
                // If time diff between current and last point is 
                // lower than 5 connect this points by rectangle 
                if (pkTime - _mPkTimeLast < 5)
                {
                    // This state is according to wintab demo. I don't know the reason.
                    // But probably this state never occur
                    _mGraphics.DrawRectangle(_mPen, x, y, 1, 1);
                }
                else
                {
                    // Draw a line between points
                    _mGraphics.DrawLine(_mPen, tabPoint, _mLastPoint);
                }
            }
            if (_debug_mode)
            {
                var message = $@"X: {pkt.pkX}; Y: {pkt.pkY}; T: {pkt.pkTime}; B: {pkt.pkButtons}; Az: {pkt.pkOrientation.orAzimuth}; Tilt: {pkt.pkOrientation.orAltitude}; P:{pkt.pkNormalPressure}";
                _label.Text = message;
                _logger.Info(message);
            }

            // Set current point as a last one
            _mLastPoint = tabPoint;
            _mPkTimeLast = pkTime;
            //logger.Debug("LastPoint: {0}; TimeLast: {1}", m_lastPoint, m_pkTimeLast);
        }
        
        private int XPointDigitizerToPx(int Xdig)
        {
            //TODO: Get the ratio dynamically (this is the zoom of the screen in Windows Display settings)
            var xRatio = 1;

            // Calculate the position of the point
            return (((Xdig - 0) * (int)(_widthMonRes * xRatio)) / _widthDigitizer) + this._scribblePanel.Location.X;
        }

        private int YPointDigitizerToPx(int Ydig)
        {
            //TODO: Get the ratio dynamically (this is the zoom of the screen in Windows Display settings)
            var yRatio = 1;

            // Calculate the position of the point
            return (((Ydig - 0) * (int)(_heightMonRes * yRatio)) / _heightDigitizer) + this._scribblePanel.Location.Y - 20;
        }


        //Get the screen for tablet settings
        private Screen getTabletScreen()
        {
            //Get all screens
            var screens = Screen.AllScreens;

            if (screens.Length > 1)
            {
                //If there is more than one screen, return the second one.
                //Cintiq have to be set as the second one all the time (or Duplicate the Primary screen)
                return screens[1];
            }
            
            //Return primary screen
            return Screen.PrimaryScreen;
        }

    }
}