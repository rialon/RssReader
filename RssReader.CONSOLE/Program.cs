using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.CONSOLE {

    public class Program {

        public static string[] Sources {
            get { return new[] { @"https://www.onliner.by/feed", @"https://habrahabr.ru/rss" }; }
        }

        public static void Main(string[] args) {
            var _rssReader = new RssReader("RssReaderBd");
            _rssReader.SaveRecent(Program.Sources);
            _rssReader.ShowSummary();
        }
    }
}
