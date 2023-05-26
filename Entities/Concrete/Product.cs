using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    { 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BarcodeNumber { get; set; }
        public int GenderId { get; set; }
        public int CategoryId { get; set; }
        public int BrandID { get; set; }
        public int ColorId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PreviousUnitPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ProductImage> productImages;
        public List<Size> sizes;
  
      
        public Product()
        {
            CreatedAt = DateTime.Now;
            productImages = new List<ProductImage>();
            sizes = new List<Size>();
        }


    }
}
