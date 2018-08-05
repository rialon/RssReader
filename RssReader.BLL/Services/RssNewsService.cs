using RssReader.BLL.Dto;
using RssReader.BLL.Interfaces;
using RssReader.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RssReader.DAL.Entities;
using RssReader.BLL.Infrastructure;

namespace RssReader.BLL.Services {

    public class RssNewsService : IRssNewsService {
        private IUnitOfWork _uow;

        public RssNewsService(IUnitOfWork uow) {
            this._uow = uow;
        }

        public IEnumerable<NewsDto> GetAllNews() {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDto>()).CreateMapper();
            return _mapper.Map<IEnumerable<News>, List<NewsDto>>(this._uow.News.GetAll());
        }

        public IEnumerable<SourceDto> GetAllSources() {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Source, SourceDto>()).CreateMapper();
            return _mapper.Map<IEnumerable<Source>, List<SourceDto>>(this._uow.Sources.GetAll());
        }

        public SourceDto GetSource(int sourceId) {
            var _source = this._uow.Sources.Get(sourceId);
            if (_source == null) {
                throw new ValidationException("Source is not found", "");
            }
            return new SourceDto { Id = _source.Id, Name = _source.Name, Url = _source.Url };
        }
    }
}
