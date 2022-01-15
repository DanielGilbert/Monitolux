using Autofac;
using Monitolux.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Monitolux
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        private MonitoluxServicesFactory _monitoluxServicesFactory;
        private MonitoluxViewModelsFactory _monitoluxViewModelsFactory;

        public event PropertyChangedEventHandler? PropertyChanged;

        private static Autofac.IContainer? _monitoluxContainer;

        public static Autofac.IContainer? MonitoluxContainer
        {
            get
            {
                return _monitoluxContainer;
            }
            set
            {
                _monitoluxContainer = value;
                InvokePropertyChangedStatic("MonitoluxContainer");
            }
        }

        public App()
        {
            _monitoluxServicesFactory = new MonitoluxServicesFactory();
            _monitoluxViewModelsFactory = new MonitoluxViewModelsFactory();

            ContainerBuilder monitoluxContainerBuilder = new();

            _monitoluxServicesFactory.AddServicesTo(monitoluxContainerBuilder);
            _monitoluxViewModelsFactory.AddViewModelsTo(monitoluxContainerBuilder);

            _monitoluxContainer = monitoluxContainerBuilder.Build();
        }

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers that
        ///     support CallerMemberName.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the
        ///     desired value.
        /// </returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            this.InvokePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        ///     Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers
        ///     that support <see cref="CallerMemberNameAttribute" />.
        /// </param>
        protected void InvokePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static event PropertyChangedEventHandler? PropertyChangedStatic;

        public static void InvokePropertyChangedStatic(string propertyName)
        {
            PropertyChangedStatic?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

    }
}
