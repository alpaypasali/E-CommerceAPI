using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<Address>> GetByUserId(int userId);
        IResult Add(Address address);
        // other methods...
    }
}
