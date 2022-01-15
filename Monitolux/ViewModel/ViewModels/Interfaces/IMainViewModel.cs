using Monitolux.Models.Monitor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux.ViewModel.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        ObservableCollection<MonitorItem> MonitorItemCollection { get; set; }
    }
}