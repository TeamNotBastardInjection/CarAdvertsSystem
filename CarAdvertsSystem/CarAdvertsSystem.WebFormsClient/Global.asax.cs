﻿using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using CarAdvertsSystem.WebFormsClient.App_Start;

namespace CarAdvertsSystem.WebFormsClient
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DbConfig.Initialize();
        }
    }
}