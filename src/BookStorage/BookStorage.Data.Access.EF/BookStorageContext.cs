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
    DropCreateDatabaseAlways<BookStorageContext>
    //DropCreateDatabaseIfModelChanges<BookStorageContext>
    //CreateDatabaseIfNotExists<BookStorageContext>
    {
        protected override void Seed(BookStorageContext db)
        {
            db.Books.Add(new Book { Title = "asdasd", Authors = "asdasd, asdasd" , PublishingHouse = "House asd", YearOfPublishing = 2000});
            db.SaveChanges();
        }
    }
}
