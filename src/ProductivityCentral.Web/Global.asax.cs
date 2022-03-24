using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductivityCentral.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Set the variable to use int the log file path
            System.Environment.SetEnvironmentVariable("OPCENT_BASEDIR", ProductivityCentral.Utils.PathHelper.GetRootedPath(), EnvironmentVariableTarget.Process);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Set the resolver for the DI
            DependencyResolver.SetResolver(new AutofacDependencyResolver(AutofacConfig.Container));
        }
    }
}
