using Autofac;
using Infrastructure.Uow;
using NUnit.Framework;
using System;
using System.Linq;
using UnitTestProject.Startup;

namespace UnitTestProject.Repositorys
{
    [TestFixture]
    public class ProductRepositoryNUnitTest : NUnitTestBase
    {

        [Test]
        public void GetAllProducts_Test()
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objProducts = unitOfWork.ProductRepository.All();

            Assert.IsNotNull(objProducts);

        }

        [Test]
        public void GetAllProductsHierarchyFirstPass_Test()
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objProducts = unitOfWork.ProductRepository.GetAllHierarchyFirstPass();

            Assert.IsNotNull(objProducts);

        }

        [Test]
        public void GetAllProductsHierarchy_Test()
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objProducts = unitOfWork.ProductRepository.GetAllHierarchy();

            Assert.IsNotNull(objProducts);

        }

    }
}
