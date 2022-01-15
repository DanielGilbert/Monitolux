using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Autofac.Core.Resolving;
using Autofac.Core.Resolving.Pipeline;
using Autofac.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitolux.ViewModel.Mocks
{
    public class MockDiagnosticSource : DiagnosticListener
    {
        public MockDiagnosticSource(string name) : base(name)
        {
        }
    }

    public class MockDisposer : IDisposer
    {
        public void AddInstanceForAsyncDisposal(IAsyncDisposable instance)
        {

        }

        public void AddInstanceForDisposal(IDisposable instance)
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }
    }

    public class MockComponentRegistry : IComponentRegistry
    {
        public IDictionary<string, object?> Properties => new Dictionary<string, object?>();

        public IEnumerable<IComponentRegistration> Registrations => new List<IComponentRegistration>();

        public IEnumerable<IRegistrationSource> Sources => new List<IRegistrationSource>();

        public IEnumerable<IServiceMiddlewareSource> ServiceMiddlewareSources => new List<IServiceMiddlewareSource>();

        public bool HasLocalComponents => false;

        public void Dispose() { GC.SuppressFinalize(this); }

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask; 
        }

        public bool IsRegistered(Service service) { return false; }

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service)
        {
            return new List<IComponentRegistration>();
        }

        public IEnumerable<IResolveMiddleware> ServiceMiddlewareFor(Service service)
        {
            return new List<IResolveMiddleware>();
        }

        public IEnumerable<ServiceRegistration> ServiceRegistrationsFor(Service service)
        {
            return new List<ServiceRegistration>();
        }

        public bool TryGetRegistration(Service service, [NotNullWhen(true)] out IComponentRegistration? registration)
        {
            registration = null;
            return false;
        }

        public bool TryGetServiceRegistration(Service service, out ServiceRegistration serviceRegistration)
        {
            serviceRegistration = new ServiceRegistration();
            return false;
        }
    }

 
    public class MockAutofacContainer : IContainer
    {
        public IDisposer Disposer { get; set; }

        public object Tag { get; set; }

        public IComponentRegistry ComponentRegistry { get; set; }

        public DiagnosticListener DiagnosticSource => new MockDiagnosticSource(String.Empty);

        public event EventHandler<LifetimeScopeBeginningEventArgs> ChildLifetimeScopeBeginning = delegate { };
        public event EventHandler<LifetimeScopeEndingEventArgs> CurrentScopeEnding = delegate { };
        public event EventHandler<ResolveOperationBeginningEventArgs> ResolveOperationBeginning = delegate { };

        public MockAutofacContainer()
        {
            Disposer = new MockDisposer();
            Tag = new();
            ComponentRegistry = new MockComponentRegistry();
        }

        public ILifetimeScope BeginLifetimeScope()
        {
            ChildLifetimeScopeBeginning(this, new LifetimeScopeBeginningEventArgs(this));

            return this;
        }

        public ILifetimeScope BeginLifetimeScope(object tag)
        {
            ChildLifetimeScopeBeginning(this, new LifetimeScopeBeginningEventArgs(this));

            return this;
        }

        public ILifetimeScope BeginLifetimeScope(Action<ContainerBuilder> configurationAction)
        {
            ChildLifetimeScopeBeginning(this, new LifetimeScopeBeginningEventArgs(this));

            return this;
        }

        public ILifetimeScope BeginLifetimeScope(object tag, Action<ContainerBuilder> configurationAction)
        {
            ChildLifetimeScopeBeginning(this, new LifetimeScopeBeginningEventArgs(this));

            return this;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }

        public object ResolveComponent(IComponentRegistration registration, IEnumerable<Parameter> parameters)
        {
            if (registration == null) return new();
            if (parameters == null) return new();

            if (ComponentRegistry.HasLocalComponents) return new();

            return new();
        }

        public object ResolveComponent(ResolveRequest request)
        {
            if (request == null) return new();
            return new();
        }
    }
}
