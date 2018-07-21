using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {

        public Product()
        {

            TableOrderItems = new List<OrderItem>();

        }

        public int Id { get; set; }

        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        public virtual Supplier TableSupplier { get; set; }

        public virtual IList<OrderItem> TableOrderItems { get; set; }

    }
}
