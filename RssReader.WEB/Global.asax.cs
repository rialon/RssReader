using Ninject;
using Ninject.Web.Mvc;
using RssReader.BLL.Infrastructure;
using RssReader.WEB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RssReader.WEB {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(
                new StandardKernel(new NinjectWEBServiceModule(), new NinjectBLLServiceModule("RssReaderBd"))));
        }
    }
}
