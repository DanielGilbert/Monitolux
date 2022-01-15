using Monitolux.Models.Monitor;
using Monitolux.Base;
using Monitolux.ViewModel.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Monitolux.ViewModels.Views
{
    public class MainViewModel : NotifyPropertyChanged, IMainViewModel
    {
        public ObservableCollection<MonitorItem> MonitorItemCollection { get; set; }

        public MainViewModel()
        {
            MonitorItemCollection = new ObservableCollection<MonitorItem>
            {
                new MonitorItem { Name = "Test1" },
                new MonitorItem { Name = "Test2" }
            };
        }

    }
}
