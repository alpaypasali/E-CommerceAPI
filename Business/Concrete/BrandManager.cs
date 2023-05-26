using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
   
        public IResult Add(Brand brand)
        {
           

            _brandDal.Add(brand);

            return new SuccessResult("brand added successfully.");
        }

        public IResult Delete(Brand brand)
        {


            _brandDal.Delete(brand);

            return new SuccessResult("brand deleted successfully.");
        }


        public IDataResult<List<Brand>> GetShoesByBrand()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetShoesByBrandID(int brandID)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == brandID));
        }
        
        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult("brand not updated successfully.");
            }

            _brandDal.Update(brand);

            return new SuccessResult("brand updated successfully.");
        }
    }
}
