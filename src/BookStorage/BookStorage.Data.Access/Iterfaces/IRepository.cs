using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Data.Access.Iterfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Select();
        T Find(object key);
        void Create(T item);
        void Update(T item); 
        void Delete(T entity); 
    }
}
