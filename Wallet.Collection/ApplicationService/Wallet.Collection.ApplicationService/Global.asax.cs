using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using Castle.Core;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;

namespace Wallet.Collection.ApplicationService
{
    using Wallet.Collection.RestBootStrapper;
    using Wallet.Collection.BootStrapper.Intercepter;
    using Wallet.Collection.ApplicationService.Contract;
    using Wallet.Collection.ApplicationService.Controllers;

    public class WebApiApplication : HttpApplication
    {
        private static IWindsorContainer container;
        private BootStrapper bs;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            container = new WindsorContainer();
            //--container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());

            bs = new BootStrapper(container);
            bs.Run();

            container.Register(
                Classes.FromAssemblyContaining<UserController>().BasedOn<IHttpController>().LifestyleTransient()
                .Configure(c => c.LifestyleSingleton())
                //.Configure(delegate (ComponentRegistration c)
                //{
                //    var x = c.Interceptors(InterceptorReference.ForType<ExceptionInterceptor>()).AtIndex(0).LifestyleTransient();
                //    var y = c.Interceptors(InterceptorReference.ForType<LogInterceptor>()).AtIndex(1).LifestyleTransient();
                //})
            );

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
        }

        protected new void Disposed()
        {
            bs.Dispose();
        }
    }
}