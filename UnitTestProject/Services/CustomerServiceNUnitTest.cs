using Application.Dtos;
using Application.Interfaces;
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

namespace UnitTestProject.Services
{

    [TestFixture]
    public class CustomerServiceNUnitTest : NUnitTestBase
    {

        [Test]
        public void AddCustomerAndOrder_Test()
        {

            var customerService = _container.Resolve<ICustomerService>();

            var objNewCustomer = new CustomerDto("Elizabeth", "Lily", "Thailand", "Bangkok", "000-855-1252");

            var result = customerService.Add(objNewCustomer);

            Console.WriteLine($"Id: {result.Id}");
            Console.WriteLine($"FirstName: {result.FirstName}");
            Console.WriteLine($"LastName: {result.LastName}");
            Console.WriteLine($"City: {result.City}");
            Console.WriteLine($"Country: {result.Country}");
            Console.WriteLine($"Phone: {result.Phone}");

        }

    }
}
