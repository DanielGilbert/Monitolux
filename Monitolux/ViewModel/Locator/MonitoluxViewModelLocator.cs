using Autofac;
using Monitolux.Base;
using Monitolux.ViewModel.Mocks;
using Monitolux.ViewModel.Mocks.ViewModels;
using Monitolux.ViewModel.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monitolux.ViewModel.Locator
{
    public class MonitoluxViewModelLocator : DependencyObjectWithNotifyPropertyChanged, ISupportInitialize
    {
        private readonly DependencyObject _dummy = new();

        public Autofac.IContainer MonitoluxContainer
        {
            get { return (Autofac.IContainer)this.GetValue(MonitoluxContainerProperty); }
            set
            {
                this.SetValue(MonitoluxContainerProperty, value);
            }
        }

        public static readonly DependencyProperty MonitoluxContainerProperty = DependencyProperty.Register(
          "MonitoluxContainer", typeof(Autofac.IContainer), typeof(MonitoluxViewModelLocator), new PropertyMetadata(new MockAutofacContainer()));

        public IMainViewModel MainViewModel
        {
            get
            {
                return GetCorrectViewModel<IMainViewModel, MockMainViewModel>();
            }
        }
 
        public T GetCorrectViewModel<T, U>() where T : class
                                             where U : T, new()
        {
            if (IsInDesignMode())
                return Activator.CreateInstance<U>();

            if (MonitoluxContainer == null)
                throw new ArgumentNullException("Please initialize MainViewModel in App.xaml.cs");

            return MonitoluxContainer.Resolve<T>();
        }

        /// <summary>
        /// Gets called from XAML
        /// </summary>
        public void BeginInit() { }

        /// <summary>
        /// 
        /// </summary>
        public void EndInit()
        {
            if (MonitoluxContainer == null)
                throw new ArgumentException("Please set the MonitoluxContainer dependency in App.xaml");
        }

        private bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(_dummy);
        }
    }

}