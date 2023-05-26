using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetByCategoryId(int categoryId);
        IDataResult<List<Product>> GetByBrandId(int brandId);
        IDataResult<List<Product>> GetByColorId(int colorId);
        IDataResult<List<Product>> GetByGenderId(int colorId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IResult DeleteProductIfOutOfStock(int productId);
        IDataResult<List<ProductDetailsDto>> GetProductWithDetails();
        IResult DeleteProductWithImagesAndSizes(int productId);
        IDataResult<List<Product>> GetByDateTime(DateTime datetime);

    }
}
