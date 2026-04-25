using System;
using System.Collections.Generic;
using System.Text;

namespace Publisher_Subcriber_EventDelegation_Youtube
{
    public delegate void Notify(string title);
    internal class YouTubeChannel
    {
        public string ChannelName { get; set; }
        public event Notify OnVideoUploaded;

        public YouTubeChannel(string name)
        {
            ChannelName = name;
        }
        public void UploadVideo(string title)
        {
            Console.WriteLine($"\n{ChannelName} uploaded: {title}");
            OnVideoUploaded?.Invoke(title);
        }
    }
}
