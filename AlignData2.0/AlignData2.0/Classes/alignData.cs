using System;
using System.IO;
using System.Linq;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using System.Collections.Generic;
using System.IO.Compression;
using System.Diagnostics;

namespace AlignData2._0
{
    public class alignData
    {
        //string of the paths to each of the files; handWriting, gaze, json, and MP4.
        private string handWriteFilePath = null;
        private string gazeFilePath = null;
        private string metadataJsonFilePath = null;
        private string jsonFilePatientPath = null;
        private string jsonTasksTimestampsPath = null;
        private string mp4FilePath = null;
        private string path = null;

        //time stamps for gaze and hand files.
        private string JSONsystemStartTimeGaze = null;
        private int finalStartTimeGaze = 0;
        private string systemStartTimeGaze = null;
        private string systemStartTimeHand = null;

        //Data tables: hand and gaze.
        DataTable handWritingData = new DataTable();
        DataTable gazeData = new DataTable();

        //Streambuilder to save data shown on Tables
        StringBuilder sbHand;
        StringBuilder sbGaze;

        //List with all GazeData Columns
        List<string> gazeColumnsList;
        List<string> handColumnsList;

        private JObject JsonTaskTimestamp = new JObject();
        private int JsonTaskTimeStampLength = 0;
        private Boolean isThereTaskTimeStamp = false;

        public alignData()
        {
            initializeTableColumnLists();
        }

        public string getVideoPath()
        {
            return this.mp4FilePath;
        }

        private void getHandWritingFile(string path)
        {
            //Method used to get the handwriting file with .svc type. (Used as name of this file may vary each time)
            string[] files = System.IO.Directory.GetFiles(path, "*.svc");
            this.handWriteFilePath = files[0];
        }

        public DataTable GetHandrwitingData()
        {
            //Method that calls for creating columns in HandData Table, and later calls for the method to filling each one.
            initializeHandWritingDataTable();
            using (TextFieldParser csvParser = new TextFieldParser(handWriteFilePath))
            {
                csvParser.SetDelimiters(new string[] { " " });
                csvParser.HasFieldsEnclosedInQuotes = false;
                // Skip the row with the column names
                csvParser.ReadLine();
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    systemStartTimeHand = getTimeStampToShow((int)(int.Parse(fields[2], CultureInfo.InvariantCulture.NumberFormat)));
                    handWritingData.Rows.Add(systemStartTimeHand, fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6]);
                }
            }
            return handWritingData;
        }


        public DataTable GetGazeData()
        {
            //Method that calls for creating columns in GazeData Table, and later calls for the method to filling each one.
            initializeGazeDataTable();
            getStartTimeFromJson();
            using (TextFieldParser csvParser = new TextFieldParser(gazeFilePath))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    switch (fields.Length)
                    {
                        case 21:
                            addGazeDataContentForBothEyes(fields);
                            break;

                        case 3:
                            addGazeDataContentForNoEye(fields);
                            break;

                        case 15:
                            if (fields[7].Contains("gazeorigin"))
                            {
                                addGazeDataContentForLeftEyeOnly(fields);
                            }
                            else
                            {
                                addGazeDataContentForRightEyeOnly(fields);
                            }
                            break;

                        default: break;
                    }
                }
            }
            return gazeData;
        }

        private void getStartTimeFromJson()
        {
            //Method that gets the Start Time value of the recording from the metadata Json file. Returns in ms.
            using (StreamReader r = new StreamReader(this.metadataJsonFilePath))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                this.JSONsystemStartTimeGaze = data.systemStartTime;
            }
            var numbers = this.JSONsystemStartTimeGaze.Split(':').Select(Int32.Parse).ToList();
            this.finalStartTimeGaze = numbers[0] * 3600 * 1000 + numbers[1] * 60 * 1000 + numbers[2] / 1000;
        }

        private void addGazeDataContentForNoEye(string[] fields)
        {
            //Method that deletes all non profitable content from the array like "/".
            //Once done, fields from the array are added in a single row for the GazeData data table.
            //This method is used when the array has no values for the fields that correspond to the left eye and right eye.
            fields[1] = fields[1].Replace("\"", "").Replace("timestamp:", ""); //Timestamp
            int timestamp = (int)(double.Parse(fields[1], CultureInfo.InvariantCulture.NumberFormat) * 1000) + this.finalStartTimeGaze;
            systemStartTimeGaze = getTimeStampToShow(timestamp);
            fields[2] = fields[2].Replace("\"", "").Replace("data:{}}", ""); //blanc data
            gazeData.Rows.Add(systemStartTimeGaze, timestamp.ToString(), fields[2], "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }

        private void addGazeDataContentForBothEyes(string[] fields)
        {
            //Method that deletes all non profitable content from the array like "[" o r "/"
            //Once done, fields from the array are added in a single row for the GazeData data table.
            //This method is used when the array has no values for the fields that correspond to the left eye.
            fields[1] = fields[1].Replace("\"", "").Replace("timestamp:", ""); //Timestamp
            int timestamp = (int)(double.Parse(fields[1], CultureInfo.InvariantCulture.NumberFormat) * 1000) + this.finalStartTimeGaze;
            systemStartTimeGaze = getTimeStampToShow(timestamp);
            fields[2] = fields[2].Replace("\"", "").Replace("data:{gaze2d:[", ""); //gaze2D_X
            fields[3] = fields[3].Replace("]", ""); //gaze2d_y
            fields[4] = fields[4].Replace("\"", "").Replace("gaze3d:[", "");//gaze3d_x
            fields[6] = fields[6].Replace("]", ""); //gaze3d_z
            fields[7] = fields[7].Replace("\"", "").Replace("eyeleft:{gazeorigin:[", "");//eyeleft_gazeorigin_x
            fields[9] = fields[9].Replace("]", ""); //eyeleft_gazeorigin_z
            fields[10] = fields[10].Replace("\"", "").Replace("gazedirection:[", "");//eyeleft_gazedirection_x
            fields[12] = fields[12].Replace("]", "");//eyeleft_gazeorigin_z
            fields[13] = fields[13].Replace("\"", "").Replace("pupildiameter:", "").Replace("}", "");//eyeleft_pupildiameter
            fields[14] = fields[14].Replace("\"", "").Replace("eyeright:{gazeorigin:[", "");//eyeright_gazeorigin_x
            fields[16] = fields[16].Replace("]", ""); //eyeright_gazeorigin_z
            fields[17] = fields[17].Replace("\"", "").Replace("gazedirection:[", "");//eyeright_gazedirection_x
            fields[19] = fields[19].Replace("]", "");//eyeright_gazedirection_z
            fields[20] = fields[20].Replace("\"", "").Replace("pupildiameter:", "").Replace("}}}", "");//eyeright_pupildiameter
            gazeData.Rows.Add(systemStartTimeGaze, timestamp.ToString(), fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9], fields[10],
            fields[11], fields[12], fields[13], fields[14], fields[15], fields[16], fields[17], fields[18], fields[19], fields[20]);
        }

        private void addGazeDataContentForLeftEyeOnly(string[] fields)
        {
            //Method that deletes all non profitable content from the array like "[" o r "/"
            //Once done, fields from the array are added in a single row for the GazeData data table.
            //This method is used when the array has no values for the fields that correspond to the right eye.
            fields[1] = fields[1].Replace("\"", "").Replace("timestamp:", ""); //Timestamp
            int timestamp = (int)(double.Parse(fields[1], CultureInfo.InvariantCulture.NumberFormat) * 1000) + this.finalStartTimeGaze;
            systemStartTimeGaze = getTimeStampToShow(timestamp);
            fields[2] = fields[2].Replace("\"", "").Replace("data:{gaze2d:[", ""); //gaze2D_X
            fields[3] = fields[3].Replace("]", ""); //gaze2d_y
            fields[4] = fields[4].Replace("\"", "").Replace("gaze3d:[", "");//gaze3d_x
            fields[6] = fields[6].Replace("]", ""); //gaze3d_z
            fields[7] = fields[7].Replace("\"", "").Replace("eyeleft:{gazeorigin:[", "");//eyeleft_gazeorigin_x
            fields[9] = fields[9].Replace("]", ""); //eyeleft_gazeorigin_z
            fields[10] = fields[10].Replace("\"", "").Replace("gazedirection:[", "");//eyeleft_gazedirection_x
            fields[12] = fields[12].Replace("]", "");//eyeleft_gazeorigin_z
            fields[13] = fields[13].Replace("\"", "").Replace("pupildiameter:", "").Replace("}", "");//eyeleft_pupildiameter
            fields[14] = fields[14].Replace("\"", "").Replace("eyeright:{}}}", "");//eyeright_gazeorigin_x
            gazeData.Rows.Add(systemStartTimeGaze, timestamp.ToString(), fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9], fields[10],
            fields[11], fields[12], fields[13], fields[14], "", "", "", "", "", "");
           
        }

        private void addGazeDataContentForRightEyeOnly(string[] fields)
        {
            //Method that deletes all non profitable content from the array like "[" o r "/"
            //Once done, fields from the array are added in a single row for the GazeData data table.
            //This method is used when the array has no values for the fields that correspond to the left eye.
            fields[1] = fields[1].Replace("\"", "").Replace("timestamp:", ""); //Timestamp
            int timestamp = (int)(double.Parse(fields[1], CultureInfo.InvariantCulture.NumberFormat) * 1000) + this.finalStartTimeGaze;
            systemStartTimeGaze = getTimeStampToShow(timestamp);
            fields[2] = fields[2].Replace("\"", "").Replace("data:{gaze2d:[", ""); //gaze2D_X
            fields[3] = fields[3].Replace("]", ""); //gaze2d_y
            fields[4] = fields[4].Replace("\"", "").Replace("gaze3d:[", "");//gaze3d_x
            fields[6] = fields[6].Replace("]", ""); //gaze3d_z
            fields[7] = fields[7].Replace("\"", "").Replace("eyeleft:{}", "");//eyeleft
            fields[8] = fields[8].Replace("\"", "").Replace("eyeright:{gazeorigin:[", "");//eyeright_gazeorigin_x
            fields[10] = fields[10].Replace("]", ""); //eyeright_gazeorigin_z
            fields[11] = fields[11].Replace("\"", "").Replace("gazedirection:[", "");//eyeright_gazedirection_x
            fields[13] = fields[13].Replace("]", "");//eyeright_gazedirection_z
            fields[14] = fields[14].Replace("\"", "").Replace("pupildiameter:", "").Replace("}}}", "");//eyeright_pupildiameter
            gazeData.Rows.Add(systemStartTimeGaze, timestamp.ToString(), fields[2], fields[3], fields[4], fields[5], fields[6], "", "", "", "", "", "", fields[7], fields[8], fields[9], fields[10],
            fields[11], fields[12], fields[13], fields[14]);
        }

        public string getTimeStampToShow(double timestamp)
        {
            //method that takes timestamp and turns it into a date format string.
            double h = timestamp / 3600000; //1 h = 3600000 ms
            double min = (h - Math.Truncate(h)) * 60;       //1h = 60min
            double sec = (min - Math.Truncate(min)) * 60;   // 1min = 60 sec
            double ms = (sec - Math.Truncate(sec)) * 1000;  // 1 s = 1000 ms
            return (int)h + ":" + (int)min + ":" + (int)sec + ":" + (int)ms;
        }

        internal void setPath(string path)
        {
            this.path = path;
            getHandWritingFile(path);
            this.gazeFilePath = $@"{path}\file_gazedata";
            this.metadataJsonFilePath = $@"{path}\file_metadata.json";
            this.jsonFilePatientPath = $@"{path}\filePatient.json";
            this.mp4FilePath = $@"{path}\file_scenevideo.mp4";
            DirectoryInfo directorySelected = new DirectoryInfo(path);
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                DecompressGzGlassesFiles(fileToDecompress);
            }
            this.jsonTasksTimestampsPath = $@"{path}\fileTimeStampTasks.json";
        }

        public string getPath()
        {
            return this.path;
        }

        public Boolean getIsThereTasTimeStamp()
        {
            return isThereTaskTimeStamp;
        }

        private void initializeTableColumnLists()
        {
            //initilizes  two list of strings that represent each column of both data tables: gaze and handwriting.
            gazeColumnsList = new List<string> { "Real Time", "Time ms", "gaze2d_x", "gaze2d_y", "gaze3d_x", "gaze3d_y", "gaze3d_z",
                "eyeleft_gazeorigin_x", "eyeleft_gazeorigin_y", "eyeleft_gazeorigin_z", "eyeleft_gazedirection_x", "eyeleft_gazedirection_y",
                "eyeleft_gazedirection_z", "eyeleft_pupildiameter",
                "eyeright_gazeorigin_x", "eyeright_gazeorigin_y", "eyeright_gazeorigin_z", "eyeright_gazedirection_x", "eyeright_gazedirection_y",
                "eyeright_gazedirection_z", "eyeright_pupildiameter",
            };
            handColumnsList = new List<string> { "Real Time", "WriteX", "WriteY", "Time ms", "s/a" , "altitude", "azimuth", "pressure" };
        }

        private void DecompressGzGlassesFiles(FileInfo fileToDecompress)
        {
            //Method used to decompress .gz files: file_gazeData.gz and file_imudata.gz
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string oldFileName = fileToDecompress.FullName;
                string newFileName = oldFileName.Remove(oldFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFile = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFile);
                    }
                }
            }
        }

        private void initializeHandWritingDataTable()
        {
            //Method to add the columns from the list, into hand Data table. No content.
            handWritingData = new DataTable();
            foreach (string element in handColumnsList)
            {
                handWritingData.Columns.Add(element, typeof(string));
            }
        }

        private void initializeGazeDataTable()
        {
            //Method to add the columns from the list, into gaze Data table. No content.
            gazeData = new DataTable();
            foreach (string element in gazeColumnsList)
            {
                gazeData.Columns.Add(element, typeof(string));
            }
        }

        internal void saveHandWritingFileToCSV(string savingDirectory)
        {
            //Method to save the handWriting data from the table shown to a .CSV file format.
            sbHand = new StringBuilder();
            IEnumerable<string> columnNames = handWritingData.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sbHand.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in handWritingData.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sbHand.AppendLine(string.Join(",", fields));
            }
            string csvFileName = String.Format("{0}/{1}.csv", savingDirectory, "HandWritingData");
            File.WriteAllText(csvFileName, sbHand.ToString());
        }

        internal void saveGazeFileToCSV(string savingDirectory)
        {
            //Method to save the gaze data from the table shown to a .CSV file format.
            sbGaze = new StringBuilder();
            IEnumerable<string> columnNames = gazeData.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sbGaze.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in gazeData.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sbGaze.AppendLine(string.Join(",", fields));
            }
            string csvFileName = String.Format("{0}/{1}.csv", savingDirectory, "alignDataGaze");
            File.WriteAllText(csvFileName, sbGaze.ToString());
        }

        public void alignGazeDataFile(int firstTimeStampHand, int lastTimeStampHand)
        {
            //Method that aligns both files: handwriting and gaze. It deletes all rows from gaze table that are
            //not inside the timestamps of the handwriting table.
            for (int i = gazeData.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = gazeData.Rows[i];
                string timeStampRow = row[1].ToString();
                int timestamp = Int32.Parse(timeStampRow);
                if (timestamp < firstTimeStampHand || timestamp > lastTimeStampHand)
                {
                    row.Delete();
                }
            }
            gazeData.AcceptChanges();
        }

        public void alignHandDataFile(int firstTimeStampHand, int lastTimeStampHand)
        {
            //Method that aligns both files: handwriting and gaze. It deletes all rows from gaze table that are
            //not inside the timestamps of the handwriting table.
            for (int i = handWritingData.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = handWritingData.Rows[i];
                string timeStampRow = row[3].ToString();
                int timestamp = Int32.Parse(timeStampRow);
                if (timestamp < firstTimeStampHand || timestamp > lastTimeStampHand)
                {
                    row.Delete();
                }
            }
            handWritingData.AcceptChanges();
        }

        internal dynamic dataFromJsonPatientInfo()
        {
            //Method that returns object JSON with name "filePatient.json". Which contains info from the patient to show.
            using (StreamReader r = new StreamReader(this.jsonFilePatientPath))
            {
                string jsonFilePatient = r.ReadToEnd();
                return JObject.Parse(jsonFilePatient);
            }
        }

        internal dynamic dataFromJsonTaskTimeStamps()
        {
            JsonTaskTimestamp = null;
            try
            {
                using (StreamReader r = new StreamReader(this.jsonTasksTimestampsPath))
                {
                    string jsonTimeStamp = r.ReadToEnd();
                    JsonTaskTimestamp = JObject.Parse(jsonTimeStamp);
                    this.JsonTaskTimeStampLength = JsonTaskTimestamp.Count; 
                }
            }
            catch (Exception)
            {
                this.isThereTaskTimeStamp = false;
            }
            if (JsonTaskTimestamp != null && JsonTaskTimestamp.ToString() != "{}")
            {
                this.isThereTaskTimeStamp = true;
            }
            return JsonTaskTimestamp;
        }
        internal dynamic getTaskTimestampDataLength()
        {
            return this.JsonTaskTimeStampLength;
        }

        internal void alignDataForTask(int v, string one1, string two, Boolean lessThan9Task)
        {

            int start;
            int finish;
            if(v == 1)
            {
                start = Int32.Parse(one1);
                finish = convertToMs(two);
            }else if(v == 9 || lessThan9Task)
            {
                start = convertToMs(one1);
                finish = Int32.Parse(two);
            }
            else
            {
                start = convertToMs(one1);
                finish = convertToMs(two);
            }
            alignGazeDataFile(start, finish);
            alignHandDataFile(start, finish);
            System.Threading.Thread.Sleep(1000);
            ereaseNonPressedData();
        }

        private void ereaseNonPressedData()
        {
            //Method that aligns both files: handwriting and gaze. It deletes all rows from gaze table that are
            //not inside the timestamps of the handwriting table.
            Boolean pressed = false;
            for (int i =0;i< handWritingData.Rows.Count; i++)
            {
                DataRow row = handWritingData.Rows[i];
                string pressure = row[4].ToString();
                int pressured = Int32.Parse(pressure);
                if (pressured == 0 && !pressed)
                {
                    row.Delete();
                }else if (pressured == 1)
                {
                    pressed = true;
                }
            }
            handWritingData.AcceptChanges();
            if (handWritingData.Rows.Count > 0 )
            {
                int firstTimeStamp = (int)(int.Parse(handWritingData.Rows[0][3].ToString(), CultureInfo.InvariantCulture.NumberFormat));
                int lastTimeStamp = (int)(int.Parse(handWritingData.Rows[handWritingData.Rows.Count - 1][3].ToString(), CultureInfo.InvariantCulture.NumberFormat));
                alignGazeDataFile(firstTimeStamp, lastTimeStamp);
            }
            
        }

        private int convertToMs(string time)
        { //Method to convert strin gtime to ms.
            if (time == null) return 0;
            var numbers = time.Split(':').Select(Int32.Parse).ToList();
            int result = numbers[0] * 3600 * 1000 + numbers[1] * 60 * 1000 + numbers[2] / 1000;
            return result;
        }
    }
}
