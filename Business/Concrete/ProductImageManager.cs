using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }


        [CacheRemoveAspect("IProductImageService.Get")]
      
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile image, ProductImage productImage)
        {
            // Business Rules
            var ruleResult = BusinessRules.Run(CheckImageLimitExceeded(productImage.Id));
            if (!ruleResult.Success)
            {
                return new ErrorResult(ruleResult.Message);
            }

            // Adding Image
            var imageResult = FileHelper.Add(image);
            productImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }


        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Delete(ProductImage productImage)
        {
            // Deleting Image
            var productToBeDeleted = _productImageDal.Get(c => c.Id == productImage.Id);
            if (productToBeDeleted == null)
            {
                return new ErrorResult(Messages.ProductImageDoesNotFound);
            }
            FileHelper.Delete(productToBeDeleted.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Update(IFormFile image, ProductImage productImage)
        {
            // Updating Image
            var productToBeUpdated = _productImageDal.Get(c => c.Id == productImage.Id);
            if (productToBeUpdated == null)
            {
                return new ErrorResult(Messages.ProductImageDoesNotFound);
            }
            var imageResult = FileHelper.Update(image, productToBeUpdated.ImagePath);
            productImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }


        public IDataResult<List<ProductImage>> GetProductImagesByProductId(int productImageId)
        {
            var data = _productImageDal.GetAll(cI => cI.Id == productImageId);
            if (data.Count == 0)
            {
                data.Add(new ProductImage
                {
                    Id = productImageId,
                    ImagePath = "/Images/default.jpg"
                });
            }
            return new SuccessDataResult<List<ProductImage>>(data);
        }


        public IDataResult<ProductImage> GetById(int Id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(cI => cI.Id == Id));
        }



        private IResult CheckIfProductImageLimit(int productImageId)
        {
            var result = _productImageDal.GetAll(c => c.Id == productImageId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


        private IDataResult<List<ProductImage>> GetDefaultImage(int productImageId)
        {

            List<ProductImage> productImage = new List<ProductImage>();
            productImage.Add(new ProductImage { Id = productImageId, Date = DateTime.Now, ImagePath = " DefaultImage.jpg " });
            return new SuccessDataResult<List<ProductImage>>(productImage);
        }


        private IResult CheckProductImage(int productImageId)
        {
            var result = _productImageDal.GetAll(c => c.Id == productImageId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }






        private IResult CheckImageLimitExceeded(int carId)
        {
            var ProductImagesOfTheShoes = _productImageDal.GetAll(p => p.Id == carId);
            if (ProductImagesOfTheShoes.Count >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
