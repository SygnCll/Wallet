using System.ServiceModel;
using System.ServiceModel.Description;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Facilities.EventWiring;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers;
using Castle.MicroKernel.Registration;

namespace Wallet.Collection.RestBootStrapper
{
    public class BootStrapper
    {
        private IWindsorContainer container;

        public BootStrapper(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public void Run()
        {
            this.ConfigureCastleWindsor();
        }

        private void ConfigureCastleWindsor()
        {
            container
                .AddFacility<EventWiringFacility>()
                .AddFacility<TypedFactoryFacility>()
                .Register(Component.For<ILazyComponentLoader>().ImplementedBy<LazyOfTComponentLoader>())
            //    .Register(Component.For<IServiceBehavior>().Instance(new ServiceBehaviorAttribute
            //             {
            //                ConcurrencyMode = ConcurrencyMode.Multiple,
            //                InstanceContextMode = InstanceContextMode.PerCall,
            //                MaxItemsInObjectGraph = int.MaxValue
            //             }),
            //             Component.For<IServiceBehavior>().Instance(new ServiceDebugBehavior
            //             {
            //                IncludeExceptionDetailInFaults = true,
            //                HttpHelpPageEnabled = true
            //             }),
            //             Component.For<IServiceBehavior>().Instance(new ServiceMetadataBehavior
            //             {
            //                HttpGetEnabled = false
            //             }),
            //             Component.For<IServiceBehavior>().Instance(new ServiceThrottlingBehavior
            //             {
            //                MaxConcurrentCalls = 16,
            //                MaxConcurrentInstances = 10,
            //                MaxConcurrentSessions = int.MaxValue
            //             })
            //    )
                .Install(Configuration.FromXmlFile("Castle.config"))
                .Install(FromAssembly.This());
        }
    }
}
