using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {

        void Add(Product entity);

        IEnumerable<Product> All();

        IEnumerable<Product> GetAllHierarchyFirstPass();

        IEnumerable<Product> GetAllHierarchy();

        Product Find(int id);

        IEnumerable<Product> FindBySupplierId(int supplierId);

        void Remove(int id);

        void Remove(Product entity);

        void Update(Product entity);

    }
}
