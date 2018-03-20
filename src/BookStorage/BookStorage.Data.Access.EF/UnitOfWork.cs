using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Data.Access.EF.Repositories;
using BookStorage.Data.Access.Iterfaces;
using BookStorage.Data.Model;

namespace BookStorage.Data.Access.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        BookStorageContext _db;
        BookRepository _bookRepository;

        public UnitOfWork(string connectionString)
        {
            _db = new BookStorageContext(connectionString);
        }

        public IRepository<Book> Books
        {
            get
            {
                return _bookRepository ?? (_bookRepository = new BookRepository(_db));
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
