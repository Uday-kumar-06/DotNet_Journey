using System;
using System.Collections.Generic;
using System.Text;

namespace Music_PlayList_Manager
{
    internal class Songs
    {
        public string Song { get; set; }
        public int Rating { get; set; }

        public string Artist { get; set; }

        public Songs(string song, int rating, string artist)
        {
            Song = song;
            Rating = rating;
            Artist = artist;
        }
    }
}
