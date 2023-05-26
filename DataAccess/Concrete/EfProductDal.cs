using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, PasaliDbContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetails(Expression<Func<ProductDetailsDto, bool>> filter = null)
        {
            using (PasaliDbContext context = new PasaliDbContext())
            {
                var result = from p in context.Products
                             select new ProductDetailsDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 Description = p.Description,
                                 ImageUrls = context.ProductImages
                                     .Where(i => i.ProductId == p.ProductId)
                                     .Select(i => i.ImagePath)
                                     .ToList(),
                                 Sizenumber = context.Sizes
                                     .Where(s => s.ProductId == p.ProductId)
                                     .Select(s => s.SizeNumber)
                                     .ToList()
                             };

                if (filter != null)
                {
                    result = result.Where(filter);
                }

                return result.ToList();
            }
        }

       
    }  
}
