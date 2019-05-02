using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Lab6.ViewModels
{
    [ImplementPropertyChanged]
    public class ForecastDayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string TemperatureRange { get; set; }
        public string ForecastDescription { get; set; }
        public string IconUrl { get; set; }
        public string Date { get; set; }
    }
}
