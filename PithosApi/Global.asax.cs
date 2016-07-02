using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Core;
using Core.Automapper;
using PandoraObjects.Authentication;
using System.Web.Mvc;
using System.Web.Optimization;
using PithosApi.Utils;
using PithosApi;

namespace PithosApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
