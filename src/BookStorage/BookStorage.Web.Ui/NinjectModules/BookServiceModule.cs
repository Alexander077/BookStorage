using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStorage.Business.Interfaces;
using BookStorage.Web.Business.Services;
using Ninject.Modules;

namespace BookStorage.Web.Ui.NinjectModules
{
    public class BookServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookService>();
        }
    }
}