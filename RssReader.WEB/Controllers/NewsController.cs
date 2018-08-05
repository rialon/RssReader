using RssReader.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RssReader.WEB.Models;
using AutoMapper;
using RssReader.BLL.Dto;

namespace RssReader.WEB.Controllers {

    public class NewsController : Controller {
        private IRssNewsService _newsService;
        private const int _pageSize = 10;

        public NewsController(IRssNewsService newsService) {
            this._newsService = newsService;
        }

        public ActionResult Index() {
            var _model = new NewsParametersViewModel {
                SourcesList = new SelectList(this._newsService.GetAllSources(), "Id", "Name"),
                IsDateSorted = true
            };
            return View(_model);
        }

        [HttpGet]
        public ActionResult ShowNews(int sourceId = 0, bool isDate = true, int page = 1) {
            var _newsDtos = this._newsService.GetAllNews();
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDto, NewsViewModel>()
                          .ForMember("SourceUrl", opt => opt.MapFrom(n => this._newsService.GetSource(n.SourceId).Url))).CreateMapper();
            var _news = _mapper.Map<IEnumerable<NewsDto>, List<NewsViewModel>>(_newsDtos);
            if (sourceId != 0) {
                _news = _news.Where(n => n.SourceId == sourceId).ToList();
            }
            if (isDate) {
                _news = _news.OrderBy(n => n.PublicationDate).ToList();
            } else {
                _news = _news.OrderBy(n => n.SourceId).ToList();
            }
            int _totalPages = (int)Math.Ceiling((double)_news.Count / NewsController._pageSize);
            _news = _news.Skip(NewsController._pageSize * (page - 1)).Take(NewsController._pageSize).ToList();
            ViewBag.TotalPages = _totalPages;
            ViewBag.CurrentPage = page;
            return PartialView("NewsTable", _news);
        }
    }
}