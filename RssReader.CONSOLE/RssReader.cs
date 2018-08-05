using Ninject;
using RssReader.CONSOLE.Infrastructure;
using RssReader.DAL.Entities;
using RssReader.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.CONSOLE {

    public class RssReader {
        private IUnitOfWork _uow;
        private List<News> _newsRead;
        private List<News> _newsSaved;

        public RssReader(string connectionString) {
            var _kernel = new StandardKernel(new NinjectRssModule(connectionString));
            this._uow = _kernel.Get(typeof(IUnitOfWork)) as IUnitOfWork;
        }

        public void ShowSummary() {
            foreach (var _source in this._uow.Sources.GetAll()) {
                Console.WriteLine("Source: {0}", _source.Name);
                Console.WriteLine("News read: {0}", this._newsRead.Where(n => n.SourceId == _source.Id).Count());
                Console.WriteLine("News saved: {0}", this._newsSaved.Where(n => n.SourceId == _source.Id).Count());
                Console.WriteLine("-------------------------------------");
            }
            Console.ReadLine();
        }

        public void SaveRecent(string[] sources) {
            var _savedNews = this._uow.News.GetAll();
            var _allNews = new List<News>();
            foreach (var _source in sources) {
                _allNews.AddRange(this._ReadItems(_source));
            }
            var _newsToSave = new List<News>();
            foreach (var _news in _allNews) {
                if (_savedNews.Where(n => n.Title == _news.Title && n.PublicationDate == _news.PublicationDate).Count() == 0) {
                    _newsToSave.Add(_news);
                }
            }

            foreach (var _news in _newsToSave) {
                this._uow.News.Create(_news);
                this._uow.Save();
            }
            this._newsSaved = _newsToSave;
            this._newsRead = _allNews;
        }

        private List<News> _ReadItems(string url) {
            XmlReader _reader = XmlReader.Create(url);
            SyndicationFeed _feed = SyndicationFeed.Load(_reader);
            _reader.Close();

            var _source = this._CreateSourceIfNotExists(url, _feed.Title.Text);

            var _result = new List<News>();
            foreach (SyndicationItem _item in _feed.Items) {
                var _news = new News {
                    Title = _item.Title.Text,
                    PublicationDate = _item.PublishDate.DateTime,
                    Description = _item.Summary.Text,
                    Url = _item.Links?.ElementAt(0).Uri.ToString(),
                    SourceId = _source.Id
                };
                _result.Add(_news);
            }
            return _result;
        }

        private Source _CreateSourceIfNotExists(string sourceUrl, string title) {
            var _source = new Source {
                Name = title,
                Url = sourceUrl
            };
            if (this._uow.Sources.GetIf(s => s.Url == sourceUrl).Count() == 0) {
                this._uow.Sources.Create(_source);
                this._uow.Save();
            }
            return this._uow.Sources.GetIf(s => s.Url == sourceUrl).Single();
        }
    }
}
