[assembly: WebActivator.PostApplicationStartMethod(typeof(ContactManager.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ContactManager.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using ContactManager.Domain.Models;
    using ContactManager.Domain.Repositories;
    using ContactManager.Service.Interfaces;
    using ContactManager.Service.Services;
    
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<ContactManagerContext>();
            container.Register<UnitOfWork>();
            container.Register<IContactService, ContactService>();
        }
    }
}