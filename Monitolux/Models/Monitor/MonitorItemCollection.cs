using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux.Models.Monitor
{
    public class MonitorItemCollection : ObservableCollection<MonitorItem>
    {
        public void Refresh()
        {
            Clear();
            GetAllMonitors();
        }

        private void GetAllMonitors()
        {

        }
    }
}
