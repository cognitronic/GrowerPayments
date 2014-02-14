using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Alpine.Infrastructure.Configuration;
using Alpine.Infrastructure.Logging;
using Alpine.Infrastructure.Email;
using Alpine.Controllers;
using Alpine.Controllers.Controllers;
using StructureMap;
using Alpine.Core.Domain.Assessment;
using Alpine.Repository.NHibernate.Repositories;
using Alpine.Infrastructure.UnitOfWork;
using Alpine.Repository.NHibernate;
using Alpine.Services.Cache;


namespace Alpine.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiContrib.IoC.StructureMap.StructureMapResolver(BootStrapper.ConfigureStructureMapWebAPI());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            BootStrapper.ConfigureStructureMap();


            Services.AutoMapperBootStrapper.ConfigureAutoMapper();
            Alpine.Controllers.AutoMapperBootStrapper.ConfigureAutoMapper();

            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());

            EmailServiceFactory.InitializeEmailServiceFactory
                                  (ObjectFactory.GetInstance<IEmailService>());

            ControllerBuilder.Current.SetControllerFactory(new IOCControllerFactory());

            LoggingFactory.GetLogger().Log("Application Started");
            ModelBinders.Binders.DefaultBinder = new App_Start.GenericModelBinder();
        }
    }
}