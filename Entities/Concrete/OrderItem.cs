using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public decimal Quantity { get; set; }

        public Order Order { get; set; }
        public ProductImage ProductImage { get; set; }  
        public Product Product { get; set; }
    }
}
