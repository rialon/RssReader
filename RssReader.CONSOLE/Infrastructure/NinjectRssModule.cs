using Ninject.Modules;
using RssReader.DAL.Interfaces;
using RssReader.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.CONSOLE.Infrastructure {

    public class NinjectRssModule : NinjectModule {
        private string _connectionString;

        public NinjectRssModule(string connectionString) {
            this._connectionString = connectionString;
        }

        public override void Load() {
            this.Bind<IUnitOfWork>().To<RssUnitOfWork>().WithConstructorArgument(this._connectionString);
        }
    }
}
