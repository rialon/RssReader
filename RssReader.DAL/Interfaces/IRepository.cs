using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.DAL.Interfaces {

    public interface IRepository<T> : IDisposable {
        void Create(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetIf(Func<T, bool> predicate);
    }
}
