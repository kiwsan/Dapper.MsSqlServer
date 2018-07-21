using Domain.Repositorys;
using Domain.Repositorys.Implements;
using Domain.Repositorys.Interfaces;
using Domain.Uow;
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

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            return builder.Build();
        }

    }
}
