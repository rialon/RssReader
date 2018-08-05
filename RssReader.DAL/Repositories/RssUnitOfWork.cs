using RssReader.DAL.EF;
using RssReader.DAL.Entities;
using RssReader.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.Repositories {

    public class RssUnitOfWork : IUnitOfWork {
        public IRepository<News> News { get; }
        public IRepository<Source> Sources { get; }
        private RssContext _db;
        private bool _disposed = false;

        public RssUnitOfWork(string connectionString) {
            this._db = new RssContext(connectionString);
            this.News = new NewsRepository(this._db);
            this.Sources = new SourceRepository(this._db);
        }

        public void Save() {
            this._db.SaveChanges();
        }

        private void _Dispose(bool disposing) {
            if (!this._disposed) {
                if (disposing) {
                    this._db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose() {
            this._Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
