using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ProductDto
    {

        public int Id { get; set; }

        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        public ProductDto(int id, string productName, int supplierId, decimal? unitPrice, string package, bool isDiscontinued)
        {

            Id = id;
            ProductName = productName;
            SupplierId = supplierId;
            UnitPrice = unitPrice;
            Package = package;
            IsDiscontinued = isDiscontinued;

        }

    }
}
