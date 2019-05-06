using PlayersDomain;
using rtest.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using PlayersDatav1.UnitOfWork;

namespace rtest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IFactory, Factory>();
            container.RegisterType<IKlubService, KlubServiceEU>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IDrazavaService, DrzavaService>();
           
          // container.RegisterType<KlubServiceEU, IKlubService>();

            // Web API configuration and services
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
