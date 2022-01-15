using Autofac;
using Monitolux.ViewModel.ViewModels.Interfaces;
using Monitolux.ViewModels.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux
{
    public class MonitoluxViewModelsFactory
    {
        public void AddViewModelsTo(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MainViewModel>()
                         .SingleInstance()
                         .As<IMainViewModel>();

        }
    }
}