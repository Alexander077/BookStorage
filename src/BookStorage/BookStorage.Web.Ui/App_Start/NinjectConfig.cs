using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BookStorage.Web.Business.NinjectModules;
using BookStorage.Web.Ui.NinjectModules;
using Ninject;
using Ninject.Modules;


namespace BookStorage.Web.Ui.App_Start
{
    //TODO: remove file if not be needed
    public class NinjectConfig
    {
        public static void RegisterModules()
        {
            //TODO: get conn. str. based on config value
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            NinjectModule bookServiceModule= new BookServiceModule();
            var kernel = new StandardKernel(serviceModule, bookServiceModule);
            //System.Web.We DependencyResolver.SetResolver(new MyNinjectDependencyResolver(kernel));
            //DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(kernel));
            //GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);


        }
    }

    /*public class MyNinjectDependencyResolver : Ninject.Web.WebApi.NinjectDependencyResolver, IDependencyResolver 
    {
        private IKernel kernal;

        public MyNinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernal = kernel;
        }
    }*/
}