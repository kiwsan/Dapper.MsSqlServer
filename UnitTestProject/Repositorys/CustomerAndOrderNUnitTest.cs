using Autofac;
using Domain.Models;
using Infrastructure.Uow;
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
    public class CustomerAndOrderNUnitTest : NUnitTestBase
    {

        [Test]
        public void AddCustomerAndOrder_Test()
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();

            var objNewCustomer = new Customer { FirstName = "Dorothy", LastName = "Fiona", Country = "Thailand", City = "Bangkok", Phone = "000-855-1252" };
            unitOfWork.CustomerRepository.Add(objNewCustomer);

            var objNewOrder1 = new Order { CustomerId = objNewCustomer.Id, OrderDate = DateTime.UtcNow, OrderNumber = "X-12055", TotalAmount = 23.22m };
            var objNewOrder2 = new Order { CustomerId = objNewCustomer.Id, OrderDate = DateTime.UtcNow, OrderNumber = "X-6521C", TotalAmount = 52.89m };
            var objNewOrder3 = new Order { CustomerId = objNewCustomer.Id, OrderDate = DateTime.UtcNow, OrderNumber = "X-5SC23", TotalAmount = 112.34m };

            unitOfWork.OrderRepository.Add(objNewOrder1);
            unitOfWork.OrderRepository.Add(objNewOrder2);
            unitOfWork.OrderRepository.Add(objNewOrder3);

            unitOfWork.Commit();

        }

    }
}
