using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class GenderManager:IGenderService
    {
        IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;

        }
     
        public IResult Add(Gender gender)
        {


            _genderDal.Add(gender);

            return new SuccessResult("Gender added successfully.");
        }
    
        public IResult Delete(Gender gender)
        {


            _genderDal.Delete(gender);

            return new SuccessResult("Gender deleted successfully.");
        }


        public IDataResult<List<Gender>> GetGender()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetAll());
        }

        public IDataResult<Gender> GetGenderID(int genderid)
        {
            return new SuccessDataResult<Gender>(_genderDal.Get(c => c.GenderId == genderid));
        }
        
        public IResult Update(Gender gender)
        {
            if (gender.GenderName.Length < 2)
            {
                return new ErrorResult("Gender not updated successfully.");
            }

            _genderDal.Update(gender);

            return new SuccessResult("Gender updated successfully.");
        }
    }
}
