using RssReader.DAL.EF;
using RssReader.DAL.Entities;
using RssReader.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.Repositories {

    public class SourceRepository : IRepository<Source> {
        private RssContext _db;

        public SourceRepository(RssContext dbContext) {
            this._db = dbContext;
        }

        public void Create(Source item) {
            this._db.Sources.Add(item);
        }

        public Source Get(int id) {
            return this._db.Sources.Find(id);
        }

        public IEnumerable<Source> GetAll() {
            return this._db.Sources.ToList();
        }

        public IEnumerable<Source> GetIf(Func<Source, bool> predicate) {
            return this._db.Sources.Where(predicate).ToList();
        }

        public void Dispose() {
            this._db.Dispose();
        }
    }
}
