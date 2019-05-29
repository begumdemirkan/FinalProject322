using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject322.Models
{
    public class OrderDetailsCard
    {
        public List<ShoppingCart> listCart { get; set; }

        public Order Order { get; set; }
    }
}
