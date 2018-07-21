using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositorys.Implements;
using Domain.Repositorys.Interfaces;

namespace Domain.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;

        private bool _disposed;

        public UnitOfWork()
        {
            _connection = new SqlConnection(Constants.ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IProductRepository ProductRepository { get { return _productRepository ?? (_productRepository = new ProductRepository(_transaction)); } }

        public ICustomerRepository CustomerRepository { get { return _customerRepository ?? (_customerRepository = new CustomerRepository(_transaction)); } }

        public IOrderRepository OrderRepository { get { return _orderRepository ?? (_orderRepository = new OrderRepository(_transaction)); } }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _productRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }

    }
}
