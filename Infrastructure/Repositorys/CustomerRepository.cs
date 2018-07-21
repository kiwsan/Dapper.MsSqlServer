using Dapper;
using Domain.Core.Extensions;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys
{
    internal class CustomerRepository : RepositoryBase, ICustomerRepository
    {

        public CustomerRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Add(Customer entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.Id = Connection.ExecuteScalar<int>(
                "INSERT INTO Customer(FirstName, LastName, City, Country, Phone" +
                ") " +
                "VALUES(@FirstName, @LastName, @City, @Country, @Phone" +
                "); " +
                "SELECT SCOPE_IDENTITY()",
                param: new
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    City = entity.City,
                    Country = entity.Country,
                    Phone = entity.Phone
                },
                transaction: Transaction
            );
        }

        public Customer Find(int id)
        {

            string sql = @"SELECT * 
                           FROM Customer 
                           JOIN [dbo].[Order] 
                           ON Customer.Id = [dbo].[Order].CustomerId 
                           WHERE Customer.Id = @Id";

            return Connection.QueryParentChild<Customer, Order, int>(
                sql,
                p => p.Id,
                g => g.TableOrders,
                splitOn: "Id",
                param: new
                {
                    Id = id
                },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public Customer FindByName(string firstName, string lastName)
        {
            string sql = @"SELECT * 
                           FROM Customer 
                           WHERE Customer.FirstName = @FirstName AND LastName = @LastName";

            return Connection.Query<Customer>(
                sql,
                param: new
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public Customer FindHierarchyFirstPass(int id)
        {

            string sql = @"SELECT * 
                           FROM Customer 
                           JOIN [dbo].[Order] 
                           ON Customer.Id = [dbo].[Order].CustomerId 
                           WHERE Customer.Id = @Id";

            return Connection.Query<Customer, Order, Customer>(
                sql,
                (customer, order) =>
                {

                    //order.TableCustomer = customer;
                    customer.TableOrders.Add(order);

                    return customer;
                },
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

    }
}
