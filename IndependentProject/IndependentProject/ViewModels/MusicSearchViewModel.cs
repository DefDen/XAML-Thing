using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject.ViewModels
{
    public class MusicSearchViewModel
    {
        public ObservableCollection<MusicViewModel> Music { get; } = new ObservableCollection<MusicViewModel>();
    }
}
