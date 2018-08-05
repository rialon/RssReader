using Ninject.Modules;
using RssReader.BLL.Interfaces;
using RssReader.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssReader.WEB.Infrastructure {

    public class NinjectWEBServiceModule : NinjectModule {

        public override void Load() {
            this.Bind<IRssNewsService>().To<RssNewsService>();
        }
    }
}