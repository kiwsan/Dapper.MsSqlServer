using Dapper;
using Domain.Models;
using Domain.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys.Implements
{
    internal class ProductRepository : RepositoryBase, IProductRepository
    {

        public ProductRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Add(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.Id = Connection.ExecuteScalar<int>(
                "INSERT INTO Product(ProductName, SupplierId, UnitPrice, Package, IsDiscontinued" +
                ") " +
                "VALUES(@ProductName, @SupplierId, @UnitPrice, @Package, @IsDiscontinued" +
                "); " +
                "SELECT SCOPE_IDENTITY()",
                param: new
                {
                    Id = entity.Id,
                    ProductName = entity.ProductName,
                    SupplierId = entity.SupplierId,
                    UnitPrice = entity.UnitPrice,
                    Package = entity.Package,
                    IsDiscontinued = entity.IsDiscontinued
                },
                transaction: Transaction
            );
        }

        public IEnumerable<Product> All()
        {
            return Connection.Query<Product>(
                "SELECT * FROM Product",
                transaction: Transaction
            );
        }

        //https://gist.github.com/Lobstrosity/1133111#file-7-gethierarchyfirstpass-cs-L3
        public IEnumerable<Product> GetAllHierarchy()
        {

            // Use a lookup to store unique product.
            Dictionary<int, Product> lookup = new Dictionary<int, Product>();

            return Connection.Query<Product, Supplier, Product>(
                @"SELECT
                    [Product].*,
                    [Supplier].*
                  FROM
                    [Product]
                  JOIN
                    [Supplier]
                  ON
                    [Product].[SupplierId] = [Supplier].[Id]",
                (possibleDupeProduct, supplier) =>
                {
                    Product product;
                    // Look for the current product, storing it in 'product' if it
                    // exists.
                    if (!lookup.TryGetValue(possibleDupeProduct.Id, out product))
                    {
                        // If the lookup doesn't contain the current product, add
                        // it and store it in 'product' as well.
                        lookup.Add(possibleDupeProduct.Id, possibleDupeProduct);

                        product = possibleDupeProduct;
                    }

                    // Regardless of the state of the lookup before this mapping,
                    // 'product' now refers to a distinct product.
                    product.TableSupplier = supplier;
                    supplier.TableProducts.Add(product);

                    return product;
                },
                transaction: Transaction
            ).Distinct();
        }

        public IEnumerable<Product> GetAllHierarchyFirstPass()
        {
            return Connection.Query<Product, Supplier, OrderItem, Product>(
                @"SELECT
                    [Product].*,
                    [Supplier].*,
                    [OrderItem].*
                  FROM
                    [Product]
                  JOIN
                    [Supplier]
                  ON
                    [Product].[SupplierId] = [Supplier].[Id]
                  JOIN
                    [OrderItem]
                  ON
                    [Product].Id = [OrderItem].ProductId",
                (product, supplier, orderItem) =>
                {

                    product.TableSupplier = supplier;
                    //supplier.TableProducts.Add(product);
                    product.TableOrderItems.Add(orderItem); //bugs

                    return product;
                },
                transaction: Transaction
            );
        }

        public Product Find(int id)
        {
            return Connection.Query<Product>(
                "SELECT * FROM Product WHERE Id = @Id",
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public IEnumerable<Product> FindBySupplierId(int supplierId)
        {
            return Connection.Query<Product>(
                "SELECT * FROM Product WHERE SupplierId = @SupplierId",
                param: new { SupplierId = supplierId },
                transaction: Transaction
            );
        }

        public void Remove(int id)
        {
            Connection.Execute(
                "DELETE FROM Product WHERE Id = @Id",
                param: new { Id = id },
                transaction: Transaction
            );
        }

        public void Remove(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Remove(entity.Id);
        }

        public void Update(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Connection.Execute(
                "UPDATE Product SET ProductName = @ProductName, SupplierId = @SupplierId " +
                "UnitPrice = @UnitPrice, Package = @Package, IsDiscontinued = @IsDiscontinued " +
                "WHERE Id = @Id",
                param: new
                {
                    Id = entity.Id,
                    ProductName = entity.ProductName,
                    SupplierId = entity.SupplierId,
                    UnitPrice = entity.UnitPrice,
                    Package = entity.Package,
                    IsDiscontinued = entity.IsDiscontinued
                },
                transaction: Transaction
            );
        }

    }
}
