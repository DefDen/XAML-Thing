﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject.Models
{

    public class LyricsHeader
    {
        public int status_code { get; set; }
        public double execute_time { get; set; }
    }

    public class Lyrics
    {
        public int lyrics_id { get; set; }
        public int @explicit { get; set; }
        public string lyrics_body { get; set; }
        public string script_tracking_url { get; set; }
        public string pixel_tracking_url { get; set; }
        public string lyrics_copyright { get; set; }
        public DateTime updated_time { get; set; }
    }

    public class LyricsBody
    {
        public Lyrics lyrics { get; set; }
    }

    public class LyricsMessage
    {
        public LyricsHeader header { get; set; }
        public LyricsBody body { get; set; }
    }

    public class LyricsRootObject
    {
        public LyricsMessage message { get; set; }
    }
}
