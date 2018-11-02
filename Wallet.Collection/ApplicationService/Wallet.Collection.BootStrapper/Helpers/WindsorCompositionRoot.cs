using Castle.Windsor;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Wallet.Collection.RestBootStrapper
{
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                var controller = (IHttpController)this.container.Resolve(controllerType);
                request.RegisterForDispose(new Release(() => this.container.Release(controller)));
                return controller;
            }
            catch (Exception ex)
            {
                throw new Exception("Controller resolve error.", ex);
            }

        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release) { this.release = release; }

            public void Dispose()
            {
                this.release();
            }
        }

    }
}
