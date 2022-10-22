using HandAQUS.API.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace HandAQUS.API
{
    //TFG
    //A single Tobii Pro Glasses 3 recording. This stores all relevant information associated with a recording.
    public class Recording : InterfaceRecording
    {
        private string g3Url;
        private string identifier;

        //set when rec started
        private String uuid;
        private string systemStartimeTimeStamp;

        //set when rec stopped.
        private string httpPath;
        private string folder;
        private JObject recInfo;
        private string gazeFile;
        private string videoFile;
        private string imufile;
 
        public Recording(string g3Url, string identifier, Boolean overlayGaze)
        {
            this.g3Url = g3Url;
            this.identifier = identifier;
            settingOverlay(overlayGaze);
        }

        public void settingOverlay(bool overlayGaze)
        {
            //Method that requests the gaze rendered on video to the glasses. Depends on bool value "overlayGaze".
            try
            {
                String url = String.Format("{0}/rest/settings.gaze-overlay", g3Url);
                var data = "false";
                if (overlayGaze)
                {
                    data = "true";
                }
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/xml";  //Set the content type of the data being posted.
                request.ContentLength = bytes.Length; //Set the content length of the string being posted.
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bytes, 0, bytes.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                    if (stream != null)
                    {
                        Debug.WriteLine(stream.ToString());
                    }
            }
            catch (System.Net.WebException e)
            {
                Debug.WriteLine("\n.Exception Caught!. Message :{0} ", e.Message);
            }
        }

        public void StartRecording()
        {
            //Calls to Start a recording. 
            //If recording succedes to start:
            //This saves the initial System Start Time TimeStamp of the recording.
            //And calls the method to save the UUID of recording.

            if (callStartRecorderAPI())
            {
                this.systemStartimeTimeStamp = DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ssffffff");
                _ = getUuidAsync();
            }
            else
            {
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }
        }

        private async Task getUuidAsync()
        {
            //Gets the uuid of the curretn recording.
            String url = String.Format("{0}/rest/recorder.uuid", this.g3Url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            this.uuid = String.Format(responseBody);
            this.uuid = this.uuid.Substring(1, this.uuid.Length - 2);
        }

        private Boolean callStartRecorderAPI()
        {
            //Method that calls API to start a recording.
            String url = String.Format("{0}/rest/recorder!start", g3Url);
            var data = "[]";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded"; //Set the content type of the data being posted.
            request.ContentLength = bytes.Length; //Set the content length of the string being posted.

            var reqStream = request.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

            using (Stream stream = response.GetResponseStream())
                if (stream != null)
                {
                    return true;
                }
            return false;
        }

        public void StopRecording()
        {
            //Calls to Stop the recording.
            //If succeds Stopping the recording:
            //From the JSON of the recoring obtained via callRecInfo method:
            //Gets the metadata associated with the recording and the
            //SD card file locations. Gazedata, scenevideo and imu_data filenames
            //are stored as properties of the Recording object.

            if (callStopRecording())
            {
                callHttpPath();
                this.folder = String.Format("{0}{1}", this.g3Url, this.httpPath);
                callRecInfo();
                this.gazeFile = (string)recInfo["scenecamera"]["file"];
                this.videoFile = (string)recInfo["gaze"]["file"];
                this.imufile = (string)recInfo["imu"]["file"];
            }
            else
            {
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }
        }
        private void callRecInfo()
        {
            //Gets the JSON with information of the recording.
            string url = this.folder;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                this.recInfo = JObject.Parse(reader.ReadToEnd());
                Debug.WriteLine("rec "+this.recInfo);
            }
        }

        private void callHttpPath()
        {
            //Returns the http Path of the recording.
            string url = String.Format("{0}/rest/recordings/{1}.http-path", this.g3Url, this.uuid);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                this.httpPath = reader.ReadToEnd();
                this.httpPath = this.httpPath.Substring(1, this.httpPath.Length - 2);
                Debug.WriteLine("path "+ this.httpPath);
            }
        }
        private Boolean callStopRecording()
        {
            //Method that calls API to Stop the recording.
            String url = String.Format("{0}/rest/recorder!stop", this.g3Url);
            var data = "[]";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded"; //Set the content type of the data being posted.
            request.ContentLength = bytes.Length; //Set the content length of the string being posted.
            var reqStream = request.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
                if (stream != null)
                {
                    return true;
                }
            return false;
        }
        public void cancelRecording()
        {
            //Method that calls API to Cancel the recording.
            //If this method is executed when recording, it leads to deletion of recording stored on SD-card.
            String url = String.Format("{0}/rest/recorder!cancel", this.g3Url);
            var data = "[]";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded"; //Set the content type of the data being posted.
            request.ContentLength = bytes.Length; //Set the content length of the string being posted.
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }
        }
        public void saveRecording(string dest_dir, string identifier)
        {
            //Saves the recording. Includes a .json metadata file, .gz gazedata file,
            //.mp4 scenevideo, and .gz imudata file.The identifier can be updated
            //for saving, filenames have this identifier as a prefix.Files are
            //transferred from the glasses 3 using scp.
            this.identifier = identifier;
            string[] files = { this.gazeFile, this.videoFile, this.imufile };
            foreach (var fname in files)
            {
                var dst_name = String.Format("{0}/{1}_{2}", dest_dir, this.identifier, fname);
                var src_fname = String.Format("{0}/{1}", this.folder, fname);
                using (WebClient myWebClient = new WebClient())
                {
                    myWebClient.DownloadFile(src_fname, dst_name);
                }
            }
            createMetadataJson();
            var json_fname = String.Format("{0}/{1}_metadata.json", dest_dir, this.identifier); 
            using (StreamWriter file = File.CreateText(json_fname))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                this.recInfo.WriteTo(writer);
            }
        }
        private void createMetadataJson()
        {
            //Adds info of identifier and System Start Time, to the metadata .json.
            this.recInfo["identifier"] = this.identifier;
            this.recInfo["systemStartTime"] = this.systemStartimeTimeStamp;
        }
    }
}
