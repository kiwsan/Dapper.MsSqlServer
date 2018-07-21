using Application.Interfaces;
using Application.Services;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {

        public static IContainer Registers()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();

            return builder.Build();
        }

    }
}
