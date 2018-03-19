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
        BookStorageContext db;

        public BookRepository(BookStorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> Select()
        {
            return db.Books;
        }

        public Book Find(object key)
        {
            return db.Books.Find(key);
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Update(Book item)
        {
/*
            var entry = db.Entry(item);

            if (entry == null || entry.State == EntityState.Detached)
            {
                db.Books.Attach(item);
                entry.State = EntityState.Modified;
            }
*/

            //TODO: check if code valid
            db.Books.Attach(item);
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Book entity)
        {
            //TODO: check if code valid
            if (db.Entry(entity).State == EntityState.Detached)
            {
                db.Books.Attach(entity);
            }

            db.Books.Remove(entity);
        }
    }
}
