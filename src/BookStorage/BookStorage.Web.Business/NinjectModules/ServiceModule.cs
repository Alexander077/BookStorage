using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Data.Access.EF;
using BookStorage.Data.Access.Iterfaces;
using Ninject.Modules;

namespace BookStorage.Web.Business.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
