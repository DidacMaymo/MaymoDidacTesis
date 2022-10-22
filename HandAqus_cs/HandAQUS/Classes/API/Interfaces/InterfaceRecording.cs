using System;

namespace HandAQUS.API.Interfaces
{
    //TFG
    internal interface InterfaceRecording
    {
        //Start a recording
        void StartRecording();

        //Stop a recording
        void StopRecording();

        //Cancel a recording
        void cancelRecording();

        //Save a recording
        void saveRecording(String dest_dir, string identifier);
    }
}
