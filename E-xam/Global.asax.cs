﻿using System.Configuration;
using System.Data.Entity;
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
    }
}
