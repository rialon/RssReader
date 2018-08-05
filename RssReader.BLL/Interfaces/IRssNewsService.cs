using RssReader.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.BLL.Interfaces {

    public interface IRssNewsService {
        IEnumerable<NewsDto> GetAllNews();
        IEnumerable<SourceDto> GetAllSources();
        SourceDto GetSource(int sourceId);
    }
}
