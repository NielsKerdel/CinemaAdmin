using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Concrete;
using Moq;
using CinemaAdmin.Domain.Entities;

namespace CinemaAdmin.Administration.Infrastructure
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
            kernel.Bind<IAccountRepository>().To<EFAccountRepository>();

            kernel.Bind<IPersonRepository>().To<EFPersonRepository>();

            kernel.Bind<IChairRepository>().To<EFChairRepository>();

            kernel.Bind<IGenreRepository>().To<EFGenreRepository>();

            kernel.Bind<IHallRepository>().To<EFHallRepository>();

            kernel.Bind<IKijkwijzerRepository>().To<EFKijkwijzerRepository>();

            kernel.Bind<ILocationRepository>().To<EFLocationRepository>();

            kernel.Bind<IMovieRepository>().To<EFMovieRepository>();

            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();

            kernel.Bind<IRateRepository>().To<EFRateRepository>();

            kernel.Bind<IRowRepository>().To<EFRowRepository>();

            kernel.Bind<IScheduleRepository>().To<EFScheduleRepository>();

            kernel.Bind<ISeatRepository>().To<ISeatRepository>();

            kernel.Bind<ITicketRepository>().To<EFTicketRepository>();
        }
    }

}