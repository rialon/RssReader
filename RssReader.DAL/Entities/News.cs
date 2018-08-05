using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.Entities {

    public class News {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public int SourceId { get; set; }
        public virtual Source Source { get; set; }
    }
}
