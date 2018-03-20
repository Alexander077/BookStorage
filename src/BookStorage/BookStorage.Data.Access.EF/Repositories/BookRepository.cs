using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Data.Access.Iterfaces;
using BookStorage.Data.Model;

namespace BookStorage.Data.Access.EF.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        BookStorageContext _db;

        public BookRepository(BookStorageContext context)
        {
            this._db = context;
        }

        public IEnumerable<Book> Select()
        {
            return _db.Books;
        }

        public Book Find(object key)
        {
            return _db.Books.Find(key);
        }

        public void Create(Book item)
        {
            _db.Books.Add(item);
        }

        public void Update(Book item)
        {
            _db.Books.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Book entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Books.Attach(entity);
            }

            _db.Books.Remove(entity);
        }
    }
}
