using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStorage.Web.Business.NinjectModules;
using BookStorage.Web.Ui.NinjectModules;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace BookStorage.Web.Ui.App_Start
{
    public class NinjectConfig
    {
        public static void RegisterModules()
        {
            //TODO: get conn. str. based on config value
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            NinjectModule bookServiceModule= new BookServiceModule();
            var kernel = new StandardKernel(serviceModule, bookServiceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}