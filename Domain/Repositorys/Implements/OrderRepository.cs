using Dapper;
using Domain.Models;
using Domain.Repositorys.Interfaces;
using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys.Implements
{
    internal class OrderRepository : RepositoryBase, IOrderRepository
    {

        public OrderRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public Order Find(int id)
        {
            string sql = @"SELECT *
                           FROM [dbo].[Order]
                           JOIN OrderItem
                           ON [dbo].[Order].Id = OrderItem.OrderId
                           WHERE [dbo].[Order].Id = @Id";

            return Connection.QueryParentChild<Order, OrderItem, int>(
                sql,
                p => p.Id,
                g => g.TableOrderItems,
                splitOn: "Id",
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public Order FindHierarchyFirstPass(int id)
        {
            string sql = @"SELECT *
                           FROM [dbo].[Order]
                            JOIN OrderItem
                           ON [dbo].[Order].Id = OrderItem.OrderId
                            JOIN [dbo].[Customer] 
                           ON [dbo].[Order].CustomerId = [dbo].[Customer].Id
                            JOIN Product
						   ON OrderItem.Id = Product.Id                           
                            WHERE [dbo].[Order].Id = @Id";

            return Connection.Query<Order, OrderItem, Customer, Product, Order>(
                sql,
                (order, orderItem, customer, product) =>
                {

                    //order.TableCustomer = customer;
                    order.TableOrderItems.Add(orderItem); // bugs
                    order.TableCustomer = customer;
                    orderItem.TableProduct = product;

                    return order;
                },
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public IEnumerable<Order> GetAllHierarchyFirstPass()
        {
            string sql = @"SELECT *
                           FROM [dbo].[Order]
                            JOIN OrderItem
                           ON [dbo].[Order].Id = OrderItem.OrderId
                            JOIN [dbo].[Customer] 
                           ON [dbo].[Order].CustomerId = [dbo].[Customer].Id
                            JOIN Product
						   ON OrderItem.Id = Product.Id";

            return Connection.Query<Order, OrderItem, Customer, Product, Order>(
                sql,
                (order, orderItem, customer, product) =>
                {

                    //order.TableCustomer = customer;
                    order.TableOrderItems.Add(orderItem); // bugs
                    order.TableCustomer = customer;
                    orderItem.TableProduct = product;

                    return order;
                },
                transaction: Transaction
            );
        }

    }
}
