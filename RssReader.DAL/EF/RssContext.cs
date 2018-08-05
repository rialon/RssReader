using RssReader.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.EF {

    public class RssContext : DbContext {

        public RssContext(string connectionString) : base(connectionString) {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Source> Sources { get; set; }
    }
}
