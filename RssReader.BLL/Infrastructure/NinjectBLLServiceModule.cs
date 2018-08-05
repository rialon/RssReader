using Ninject.Modules;
using RssReader.DAL.Interfaces;
using RssReader.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.BLL.Infrastructure {

    public class NinjectBLLServiceModule : NinjectModule {
        private string _connectionString;

        public NinjectBLLServiceModule(string connectionString) {
            this._connectionString = connectionString;
        }

        public override void Load() {
            this.Bind<IUnitOfWork>().To<RssUnitOfWork>().WithConstructorArgument(this._connectionString);
        }
    }
}
