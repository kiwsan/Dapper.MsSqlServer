using Application.Dtos;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork _unitOfWork)
        {

            this._unitOfWork = _unitOfWork;

        }

        public CustomerDto Add(CustomerDto command)
        {

            var existingWithSameName = _unitOfWork.CustomerRepository.FindByName(command.FirstName, command.LastName);
            if (existingWithSameName != null)
            {
                throw new Exception("User already exists with this name");
            }

            var objNewCustomer = new Customer(command.Id, command.FirstName, command.LastName, command.City, command.Country, command.Phone);

            _unitOfWork.CustomerRepository.Add(objNewCustomer);

            var objNewOrder1 = new Order(objNewCustomer.Id, DateTime.UtcNow, "X-12055", 23.22m);
            var objNewOrder2 = new Order(objNewCustomer.Id, DateTime.UtcNow, "X-6521C", 52.89m);
            var objNewOrder3 = new Order(objNewCustomer.Id, DateTime.UtcNow, "X-5SC23", 112.34m);

            _unitOfWork.OrderRepository.Add(objNewOrder1);
            _unitOfWork.OrderRepository.Add(objNewOrder2);
            _unitOfWork.OrderRepository.Add(objNewOrder3);

            _unitOfWork.Commit();

            return new CustomerDto(objNewCustomer.Id, objNewCustomer.FirstName, objNewCustomer.LastName, objNewCustomer.City, objNewCustomer.Country, objNewCustomer.Phone);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
