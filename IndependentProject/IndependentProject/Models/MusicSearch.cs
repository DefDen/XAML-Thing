﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject.Models
{
    class Music
    {
        
    }

    public class MusicSearchHeader
    {
        public int status_code { get; set; }
        public double execute_time { get; set; }
        public int available { get; set; }
    }

    public class PrimaryGenres
    {
        public List<object> music_genre_list { get; set; }
    }

    public class Track
    {
        public int track_id { get; set; }
        public string track_name { get; set; }
        public List<object> track_name_translation_list { get; set; }
        public int track_rating { get; set; }
        public int commontrack_id { get; set; }
        public int instrumental { get; set; }
        public int @explicit { get; set; }
        public int has_lyrics { get; set; }
        public int has_subtitles { get; set; }
        public int has_richsync { get; set; }
        public int num_favourite { get; set; }
        public int album_id { get; set; }
        public string album_name { get; set; }
        public int artist_id { get; set; }
        public string artist_name { get; set; }
        public string track_share_url { get; set; }
        public string track_edit_url { get; set; }
        public int restricted { get; set; }
        public DateTime updated_time { get; set; }
        public PrimaryGenres primary_genres { get; set; }
    }

    public class TrackList
    {
        public Track track { get; set; }
    }

    public class MusicSearchBody
    {
        public List<TrackList> track_list { get; set; }
    }

    public class MusicSearchMessage
    {
        public MusicSearchHeader header { get; set; }
        public MusicSearchBody body { get; set; }
    }

    public class MusicSearchRootObject
    {
        public MusicSearchMessage message { get; set; }
    }
}
