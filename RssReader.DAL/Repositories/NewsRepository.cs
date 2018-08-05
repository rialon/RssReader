using RssReader.DAL.EF;
using RssReader.DAL.Entities;
using RssReader.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.Repositories {

    public class NewsRepository : IRepository<News> {
        private RssContext _db;

        public NewsRepository(RssContext dbContext) {
            this._db = dbContext;
        }

        public void Create(News item) {
            this._db.News.Add(item);
        }

        public News Get(int id) {
            return this._db.News.Find(id);
        }

        public IEnumerable<News> GetAll() {
            return this._db.News.ToList();
        }

        public IEnumerable<News> GetIf(Func<News, bool> predicate) {
            return this._db.News.Where(predicate).ToList();
        }

        public void Dispose() {
            this._db.Dispose();
        }
    }
}
