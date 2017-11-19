using IvoRakar.Business.Persistence;
using IvoRakar.Business.Persistence.Repositories;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IvoRakar.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<EntityFrameworkDBContext>().ToSelf().InRequestScope();
            kernel.Bind<ISubscriberRepository>().To<SubscriberRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope(); 
        }
    }
}