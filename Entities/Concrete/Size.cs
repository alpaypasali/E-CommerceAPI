using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Size : IEntity
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public string SizeNumber { get; set; }
        public int Stock { get; set; }

    
    }
}
