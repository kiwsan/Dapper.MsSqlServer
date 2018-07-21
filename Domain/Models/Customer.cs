using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer
    {

        public Customer()
        {

            TableOrders = new List<Order>();

        }

        public Customer(int id, string firstName, string lastName, string city, string country, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Phone = phone;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public virtual IList<Order> TableOrders { get; set; }

    }
}
