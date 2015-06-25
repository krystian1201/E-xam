using System;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Shared.Repository;

namespace E_xam
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //should it be here?
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Shared.Repository.Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //it seems not to change anything
        //protected void Application_PreRequestHandlerExecute()
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        //}

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            string culture = null;
            if (context.Request.UserLanguages != null && Request.UserLanguages.Length > 0)
            {
                culture = Request.UserLanguages[0];
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
        }

    }
}
