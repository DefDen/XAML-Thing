using IndependentProject.Models;
using IndependentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject
{
    public class SharedData
    {
        public MusicSearchViewModel Results { get; set; } = new MusicSearchViewModel();
    }
}
