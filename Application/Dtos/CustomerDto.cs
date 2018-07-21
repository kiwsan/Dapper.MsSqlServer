using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{

    public class CustomerDto
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public CustomerDto(string firstName, string lastName, string city, string country, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Phone = phone;
        }

        public CustomerDto(int id, string firstName, string lastName, string city, string country, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Phone = phone;
        }

    }
}
