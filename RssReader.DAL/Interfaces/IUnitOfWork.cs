using RssReader.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.Interfaces {

    public interface IUnitOfWork : IDisposable {
        IRepository<News> News { get; }
        IRepository<Source> Sources { get; }

        void Save();
    }
}
