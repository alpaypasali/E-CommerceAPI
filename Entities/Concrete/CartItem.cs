﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public decimal Quantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
