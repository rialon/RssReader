using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RssReader.WEB.Models {

    public class NewsParametersViewModel {
        public IEnumerable<SelectListItem> SourcesList { get; set; }
        public int SourceId { get; set; }
        public bool IsDateSorted { get; set; }
    }
}