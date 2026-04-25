using System;
using System.Collections.Generic;
using System.Text;

namespace Publisher_Subcriber_EventDelegation_Youtube
{
    internal class Subsricbe
    {
        public string Name { get; set; }

        public Subsricbe(string name)
        {
            Name = name;
        }
        public void WatchVideo(string videoTitle)
        {
            Console.WriteLine($"{Name} is watching: {videoTitle}");
        }
    }
}
