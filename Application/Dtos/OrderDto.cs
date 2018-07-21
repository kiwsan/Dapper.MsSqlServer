using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class OrderDto
    {

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public OrderDto(int id, DateTime orderDate, string orderNumber, int customerId, decimal? totalAmount)
        {
            Id = id;
            OrderDate = orderDate;
            OrderNumber = orderNumber;
            CustomerId = customerId;
            TotalAmount = totalAmount;
        }

    }
}
