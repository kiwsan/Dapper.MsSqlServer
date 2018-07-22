using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {

        protected Order()
        {

            TableOrderItems = new List<OrderItem>();

        }

        public Order(int customerId, DateTime orderDate, string orderNumber, decimal? totalAmount)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderNumber = orderNumber;
            TotalAmount = totalAmount;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public decimal? TotalAmount { get; set; }

        public virtual IList<OrderItem> TableOrderItems { get; set; }

        public virtual Customer TableCustomer { get; set; }

    }
}
