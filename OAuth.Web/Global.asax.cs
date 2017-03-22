﻿using Autofac.Integration.Mvc;
using OAuth.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OAuth.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Configure();

            AutoFacExt.RegisterApplication();
            AutoFacExt.Builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = AutoFacExt.Builder.Build();
            AutoFacExt.SetContainer(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
