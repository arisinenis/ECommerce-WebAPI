using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }

        //Nav. Property
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
