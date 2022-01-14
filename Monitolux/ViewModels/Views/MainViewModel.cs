using Monitolux.Models.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux.ViewModels.Views
{
    public class MainViewModel : NotifyPropertyChanged
    {
        public MonitorItemCollection MonitorItemCollection { get; set; }

        public MainViewModel()
        {
            MonitorItemCollection = new MonitorItemCollection();
        }
    }
}
