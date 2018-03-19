using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Data.Model;

namespace BookStorage.Data.Access.EF
{
    public class BookStorageContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        static BookStorageContext()
        {
            Database.SetInitializer<BookStorageContext>(new BookStorageDbInitializer());
        }

        public BookStorageContext(string connectionString) : base(connectionString)
        {
            
        }
    }

    public class BookStorageDbInitializer :
    //DropCreateDatabaseAlways<BookStorageContext>
    //DropCreateDatabaseIfModelChanges<BookStorageContext>
    CreateDatabaseIfNotExists<BookStorageContext>
    {
        protected override void Seed(BookStorageContext db)
        {
            db.Books.Add(new Book { Title = "Book1", Authors = "Author 1.1" , PublishingHouse = "House 1", YearOfPublishing = 2001});
            db.Books.Add(new Book { Title = "Book2", Authors = "Author 2.1", PublishingHouse = "House 2", YearOfPublishing = 2002});
            db.Books.Add(new Book { Title = "Book3", Authors = "Author 3.1", PublishingHouse = "House 3", YearOfPublishing = 2003});
            db.SaveChanges();
        }
    }
}
