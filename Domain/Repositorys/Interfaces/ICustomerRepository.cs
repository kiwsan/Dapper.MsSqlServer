using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys.Interfaces
{
    public interface ICustomerRepository
    {

        Customer Find(int id);

        Customer FindHierarchyFirstPass(int id);

        void Add(Customer entity);

    }
}
