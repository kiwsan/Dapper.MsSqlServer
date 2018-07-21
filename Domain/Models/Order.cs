using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {

        public Order()
        {

            TableOrderItems = new List<OrderItem>();

        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public virtual IList<OrderItem> TableOrderItems { get; set; }

        public virtual Customer TableCustomer { get; set; }

    }
}
