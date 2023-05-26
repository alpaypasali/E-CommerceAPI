using Business.Abstract;
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
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IDataResult<List<Address>> GetByUserId(int userId)
        {
            var addresses = _addressDal.GetAll(a => a.UserId == userId);

            if (addresses == null || !addresses.Any())
            {
                return new ErrorDataResult<List<Address>>("No addresses found for the user.");
            }

            return new SuccessDataResult<List<Address>>(addresses, "Addresses retrieved successfully.");
        }

        public IResult Add(Address address)
        {
            var result = _addressDal.Get(a => a.UserId == address.UserId);
            if(result == null) {


                _addressDal.Add(address);
                return new SuccessResult("Addresses added successfully.");
            }

            return new ErrorResult("Addresses not added successfully.");

        }


        // Implement other methods...
    }
}
