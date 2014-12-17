using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

using TN.BLL;
using TN.DAL;
using Twitter.BLL;
using Unity.Mvc4;

namespace TN.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface, WithName.Default);
        container.RegisterType<IBlogRepository, BlogRepository>();
        container.RegisterType<IOAuthTwitterWrapper, OAuthTwitterWrapper>();

        //container.RegisterType<UserStore<CustomUser>>(new HierarchicalLifetimeManager());
        container.RegisterType<DbContext, IdentityContext>(new HierarchicalLifetimeManager());
        

    }
  }
}