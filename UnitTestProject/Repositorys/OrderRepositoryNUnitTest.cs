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
    public class OrderRepositoryNUnitTest: NUnitTestBase
    {

        [TestCase(1)]
        public void Find_Test(int id)
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objOrder = unitOfWork.OrderRepository.Find(id);

            Assert.IsNotNull(objOrder);

        }

        [TestCase(1)]
        public void FindHierarchyFirstPass_Test(int id)
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objOrder = unitOfWork.OrderRepository.FindHierarchyFirstPass(id);

            Assert.IsNotNull(objOrder);

        }

        [Test]
        public void GetAllHierarchyFirstPass_Test()
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objOrders = unitOfWork.OrderRepository.GetAllHierarchyFirstPass();

            Assert.IsNotNull(objOrders);

        }

    }
}
