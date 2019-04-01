using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestPushNotification
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NotificationDbContext1"].ConnectionString;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy =
                IncludeErrorDetailPolicy.Always;

            SqlDependency.Start(connectionString);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var r = new Repository();
            r.GetAllMessages();
        }

        protected void Application_End()
        {
            SqlDependency.Stop(connectionString);
        }

    }
}
