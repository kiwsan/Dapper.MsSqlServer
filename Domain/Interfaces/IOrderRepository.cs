using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {

        Order Find(int id);

        Order FindHierarchyFirstPass(int id);

        IEnumerable<Order> GetAllHierarchyFirstPass();

        void Add(Order entity);

    }
}
