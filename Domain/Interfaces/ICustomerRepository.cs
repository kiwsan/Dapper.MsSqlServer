using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {

        Customer Find(int id);

        Customer FindHierarchyFirstPass(int id);

        Customer FindByName(string firstName, string lastName);

        void Add(Customer entity);

    }
}
