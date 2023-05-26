using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }



       

        public IResult Add(User user)
        {
            var existingUser = _userDal.Get(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return new ErrorResult(Messages.EmailUpEmailIsAlreadyRegistereddated);
            }



            _userDal.Add(user);

           

            
              return new SuccessResult(Messages.UserAdded);
        }


        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

       
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }


        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.UserId == id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }


        public IDataResult<UserDTO> GetDTOById(int id)
        {
            var result = _userDal.GetDTO(u => u.UserId == id);
            return new SuccessDataResult<UserDTO>(result);
        }


        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }


        public IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO)
        {
            var result = _userDal.Get(u => u.UserId == updateFirstAndLastNameDTO.Id);
            result.FirstName = updateFirstAndLastNameDTO.FirstName;
            result.LastName = updateFirstAndLastNameDTO.LastName;
            _userDal.Update(result);
            return new SuccessResult(Messages.FirstAndLastNameUpdated);
        }


        public IResult UpdateEmail(UpdateEmailDTO updateEmailDTO)
        {
            
         

            var result = _userDal.Get(u => u.UserId == updateEmailDTO.Id);
            result.Email = updateEmailDTO.Email;
            _userDal.Update(result);
            return new SuccessResult(Messages.EmailUpdated);
        }






       
    }
}
