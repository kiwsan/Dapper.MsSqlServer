using Autofac;
using Domain.Uow;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.Startup;

namespace UnitTestProject.Repositorys
{

    [TestFixture]
    public class CustomerRepositoryNUnitTest : NUnitTestBase
    {

        [TestCase(1)]
        public void Find_Test(int id)
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objCustomer = unitOfWork.CustomerRepository.Find(id);

            Assert.IsNotNull(objCustomer);

        }

        [TestCase(1)]
        public void FindHierarchyFirstPass_Test(int id)
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objCustomer = unitOfWork.CustomerRepository.Find(id);

            Assert.IsNotNull(objCustomer);

        }

    }
}
