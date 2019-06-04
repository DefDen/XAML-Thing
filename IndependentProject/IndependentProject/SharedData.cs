using IndependentProject.Models;
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
        public String SearchTerm = "";
    }
}
