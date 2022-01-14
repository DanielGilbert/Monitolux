using Monitolux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux.Models.Monitor
{
    public class MonitorItem : NotifyPropertyChanged
    {
        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public MonitorItem()
        {
        }
    }
}
