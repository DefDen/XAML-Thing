﻿using IndependentProject.Models;
using IndependentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject
{
    public class SharedData
    {
        public ObservableCollection<MusicViewModel> Music { get; } = new ObservableCollection<MusicViewModel>();
        public ObservableCollection<MusicViewModel> History { get; } = new ObservableCollection<MusicViewModel>();
        public String SearchTerm = "";
        public String TrackId = "";
        public String CommonTrackId = "";
        public String SearchBoxTerm = "";
        public Boolean isAdvancedSearch = true;
        public Boolean noArtistOrTrack = false;
        public Boolean isArtistSearch = false;
        public Boolean fromHistory = false;
        public String AdvancedSearchBoxTrack = "";
        public String AdvancedSearchBoxArtist = "";
    }
}
