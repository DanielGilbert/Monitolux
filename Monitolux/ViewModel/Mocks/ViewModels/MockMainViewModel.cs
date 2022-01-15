using Monitolux.Models.Monitor;
using Monitolux.ViewModel.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux.ViewModel.Mocks.ViewModels
{
    public class MockMainViewModel : IMainViewModel
    {
        public ObservableCollection<MonitorItem> MonitorItemCollection { get; set; }

        public MockMainViewModel()
        {
            MonitorItemCollection = new ObservableCollection<MonitorItem>();
        }
    }
}
