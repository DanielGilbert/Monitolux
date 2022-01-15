using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Core.Resolving;
using Autofac.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public class MockAutofacContainer : IContainer
    {
        public IDisposer Disposer { get; set; }

        public object Tag { get; set; }

        public IComponentRegistry ComponentRegistry { get; set; }

        public DiagnosticListener DiagnosticSource => new MockDiagnosticSource(String.Empty);

        public event EventHandler<LifetimeScopeBeginningEventArgs> ChildLifetimeScopeBeginning = delegate { };
        public event EventHandler<LifetimeScopeEndingEventArgs> CurrentScopeEnding = delegate { };
        public event EventHandler<ResolveOperationBeginningEventArgs> ResolveOperationBeginning = delegate { };

        public ILifetimeScope BeginLifetimeScope()
        {
            ChildLifetimeScopeBeginning(null, null);

            return null;
        }

        public ILifetimeScope BeginLifetimeScope(object tag)
        {
            ChildLifetimeScopeBeginning(null, null);

            return null;
        }

        public ILifetimeScope BeginLifetimeScope(Action<ContainerBuilder> configurationAction)
        {
            ChildLifetimeScopeBeginning(null, null);

            return null;
        }

        public ILifetimeScope BeginLifetimeScope(object tag, Action<ContainerBuilder> configurationAction)
        {
            ChildLifetimeScopeBeginning(null, null);

            return null;
        }

        public void Dispose()
        {

        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public object ResolveComponent(IComponentRegistration registration, IEnumerable<Parameter> parameters)
        {
            return new object();
        }

        public object ResolveComponent(ResolveRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
