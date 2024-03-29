﻿using ECommerceAPI.Domain.Entities.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public string Address { get; set; }

        // Customer nav. property
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
