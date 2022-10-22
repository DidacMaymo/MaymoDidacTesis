using HandAQUS.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace HandAQUS.API
{
    //TFG
    //C# class for Tobii Pro Glasses 3 implementation in HandAQUS base code.
    //Functionalities: Discover Glasses, Callibrate them, create, start, stop and save recordings.
    public class G3 : InterfaceRecording
    {
        public string g3Url;
        //IPv4 format
        string g3Ip;
        //Boolean used to decide wheter the scene video will have the gaze render on top or not. (allways true)
        Boolean overlayGaze;
        List<Recording> recCollection;
        Recording rec;

        public G3()
        {
            //Default Tobii Pro Glasses 3 IP.
            this.g3Ip = "192.168.75.51";
            this.overlayGaze = true;
            this.recCollection = new List<Recording>();
            findGlasses(g3Ip);
        }

        //A method that plays a sound if glasses are connected to the computer device.
        public void findGlasses(string g3Ip)  
        {
            //With Glasses IP, try the connection with Glasses.
            //If fails, the form that calls this function executes a MessageBox to warn
            this.g3Url = String.Format("http://{0}", g3Ip);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(g3Url);
            request.Timeout = 50;
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
                if (stream != null)
                {
                    playSound();
                }
        }

        //A method that plays a sound when callibration petiton for the glasses is complete.
        public void callibrate()
        {
           //Starts the callibration of Glasses.
            Debug.WriteLine("Atempting Calibration...");
            String url = String.Format("{0}/rest/calibrate!run", g3Url);
            var data = "[]";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/xml";  //Set the content type of the data being posted.
            request.ContentLength = bytes.Length; //Set the content length of the string being posted.
            request.Method = "POST";
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream()) 
                if (stream != null)
                {
                    playSound();
                }
        }

        //A method that plays a sound.
        private void playSound()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            System.IO.Stream filePath = Properties.Resources.callibrated;
            System.Media.SoundPlayer mp3SoundPlayer = new System.Media.SoundPlayer(filePath);
            mp3SoundPlayer.Play();
        }

        //A method that creates a new Recording object, and adds it to the "recCollection" list of Recordings.
        public void createRecording()
        {
            //Creates a new Recording object, appended to the collection of all recordings.
            this.rec = new Recording(this.g3Url, null, this.overlayGaze);
            this.recCollection.Add(rec);
        }

        //A method that calls the petition for "starting recording" of last recording object created (current one).
        public void StartRecording()
        {
            // Starts recording with the glasses 3
            this.rec = this.recCollection.Last();
            this.rec.StartRecording();
        }

        //A method that calls the petition for "stopping recording" of last recording object created(current one).
        public void StopRecording()
        {
            // Stops recording with the glasses 3
            this.rec = this.recCollection.Last();
            this.rec.StopRecording();
        }

        //A method that calls the petition of "canceling recording" of last recording object created(current one).
        public void cancelRecording()
        {
            //Cancels and deltes the recording with the glasses 3
            //Prevents IndexOutOfRangeException for empty list
            if (this.recCollection.Any()) 
            {
                this.rec = this.recCollection.Last();
                this.rec.cancelRecording();
                this.recCollection.RemoveAt(recCollection.Count - 1);
            }
        }

        //A method that calls for the petition of "saving recording" of last recording created (current one).
        public void saveRecording(string dest_dir, string identifier)
        {
            //Saves the recording. Includes a .json metadata file, .gz gazedata file,
            //.mp4 scenevideo, and .gz imudata file.
            //Filenames have the identifier as a prefix.
            this.rec = this.recCollection.Last();
            System.IO.Directory.CreateDirectory(dest_dir); 
            this.rec.saveRecording(dest_dir, identifier);
            playSound();
        }

        //A method that calls the petition for "setting overlay" false.
        //Objective: To not have the users gaze rendered on the video.
        public void GazeOff()
        {
            this.rec = this.recCollection.Last();
            this.rec.settingOverlay(false);
        }
    }
}
