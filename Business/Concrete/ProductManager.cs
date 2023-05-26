using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        ISizeDal _sizeDal;
        IProductImageDal _imageDal;
      



        public ProductManager(IProductDal productDal, ISizeDal sizeService,IProductImageDal productImageDal)
        {
            _productDal = productDal;
            _sizeDal = sizeService; 
            _imageDal = productImageDal;
            
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);

            return new SuccessResult("Product added successfully.");

        }
       
        public IResult Delete(Product product)
        {
            // Ürün resimlerini ve boyutlarını veritabanından sil
            _productDal.Delete(product);

            return new SuccessResult("Product deleted successfully.");
        }
        [CacheAspect]

        public IDataResult<List<Product>> GetByCategoryId(int categoryId)
        {
            var data = _productDal.GetAll(p => p.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(data, "Products listed successfully.");
        }
        [CacheAspect]

        public IDataResult<List<Product>> GetByBrandId(int brandId)
        {
            var data = _productDal.GetAll(p => p.BrandID == brandId);
            return new SuccessDataResult<List<Product>>(data, "Products listed successfully.");
        }
        public IDataResult<List<Product>> GetByGenderId(int genderId)
        {
            var data = _productDal.GetAll(p => p.GenderId == genderId);
            return new SuccessDataResult<List<Product>>(data, "Products listed successfully.");
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetByColorId(int colorId)
        {
            var data = _productDal.GetAll(p => p.ColorId == colorId);
            return new SuccessDataResult<List<Product>>(data, "Products listed successfully.");
        }
        public IDataResult<List<Product>> GetByDateTime(DateTime datetime)
        {
            var data = _productDal.GetAll(p => p.CreatedAt == datetime);
            return new SuccessDataResult<List<Product>>(data, "Products listed successfully.");
        }



        public IDataResult<List<Product>> GetAll()
        {
            var data = _productDal.GetAll().ToList();
            return new SuccessDataResult<List<Product>>(data, "Products listed successfully.");
        }

        public IDataResult<Product> GetById(int id)
        {
            var data = _productDal.Get(p => p.ProductId == id);
            return new SuccessDataResult<Product>(data, "Product found successfully.");
        }
      
        public IResult Update(Product product)
        {
             _productDal.Update(product);

            return new SuccessResult("Product updated successfully.");
        }
       
        public IResult DeleteProductIfOutOfStock(int productId)
        {
            if (CheckIfAllSizesOutOfStockForProduct(productId))
            {
                var product = _productDal.Get(c => c.ProductId == productId);
                if (product != null)
                {
                    DeleteProductWithImagesAndSizes(productId);
                    return new SuccessResult("Product deleted successfully.");
                }
            }

            return new ErrorResult("Product not found or sizes are not all out of stock.");
        }

        private bool CheckIfSizeIsInStock(int sizeId)
        {
            var size = _sizeDal.Get(c => c.SizeId == sizeId);
            return size != null && size.Stock > 0;
        }
       
        private bool CheckIfAllSizesOutOfStockForProduct(int productId)
        {
            var sizes = _sizeDal.GetAll(s => s.ProductId == productId);
            return sizes.All(s => s.Stock == 0);
        }
        private IResult CheckIfProductIdExist(int productId)
        {
            var result = _productDal.GetAll(c => c.ProductId == productId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.AuthorizationDenied);
            }
            return new SuccessResult();
        }

     
        public IDataResult<List<ProductDetailsDto>> GetProductWithDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(), Messages.BrandAdded);
        }
        [TransactionScopeAspect]
        public IResult DeleteProductWithImagesAndSizes(int productId)
        {
            try
            {
                // Retrieve product
                var product = _productDal.Get(p => p.ProductId == productId);

                if (product == null)
                {
                    return new ErrorResult("Product not found");
                }

                // Delete product images
                var productImages = _imageDal.GetAll(pi => pi.ProductId == productId);
                foreach (var productImage in productImages)
                {
                    _imageDal.Delete(productImage);
                }

                // Delete product sizes
                var sizes = _sizeDal.GetAll(s => s.ProductId == productId);
                foreach (var size in sizes)
                {
                    _sizeDal.Delete(size);
                }

                // Delete product
                _productDal.Delete(product);

                return new SuccessResult("Product, its images and sizes deleted successfully");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the product: {ex.Message}");
            }
        }

     


    }
}
