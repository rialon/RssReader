using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssReader.WEB.Models {

    public class NewsViewModel {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }

        public int SourceId { get; set; }
        public string SourceUrl { get; set; }
    }
}