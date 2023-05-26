using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SizeManager : ISizeService
    {
        ISizeDal _sizeDal;

        public SizeManager(ISizeDal size)
        {
            _sizeDal = size;

        }
    
        public IResult Add(Size size)
        {


            _sizeDal.Add(size);

            return new SuccessResult("Size added successfully.");
        }
      
        public IResult Delete(Size size)
        {


            _sizeDal.Delete(size);

            return new SuccessResult("Size deleted successfully.");
        }
      

        public IDataResult<List<Size>> GetSize()
        {
            return new SuccessDataResult<List<Size>>(_sizeDal.GetAll());
        }

        public IDataResult<Size> GetSizeID(int sizeİd)
        {
            return new SuccessDataResult<Size>(_sizeDal.Get(c => c.SizeId == sizeİd));
        }
       
        public IResult Update(Size size)
        {


            _sizeDal.Update(size);

            return new SuccessResult("Size updated successfully.");
        }
     
        public IResult AddSizesToProduct(int productId, ICollection<SizeDTO> sizeDTOs)
        {
            if (sizeDTOs == null || sizeDTOs.Count == 0)
            {
                return new ErrorResult("SizeDTOs collection cannot be null or empty.");
            }

            try
            {
                List<Size> sizes = new List<Size>();

                foreach (var sizeDTO in sizeDTOs)
                {
                    if (sizeDTO != null)
                    {
                        var size = new Size
                        {
                            ProductId = productId,
                            SizeNumber = sizeDTO.SizeValue,
                            Stock = sizeDTO.StockQuantity
                        };
                        sizes.Add(size);
                    }
                }

                if (sizes.Count > 0)
                {
                    foreach (var size in sizes)
                    {
                        _sizeDal.Add(size);
                    }

                    return new SuccessResult("Sizes have been successfully added to the product");
                }
                else
                {
                     return new ErrorResult("No valid sizes were found to add to the product");
                }
            }
            catch (Exception ex)
            {
                // Log the exception here
                return new ErrorResult($"There was an error adding sizes to the product: {ex.Message}");
            }
        }


    }
}
