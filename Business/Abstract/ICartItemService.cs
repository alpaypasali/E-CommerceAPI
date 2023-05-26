using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartItemService
    {
        IDataResult<List<CartItem>> GetByCartId(int cartId);
        IDataResult<CartItem> GetById(int id);
        IResult Add(CartItem cartItem);
        IResult Delete(CartItem cartItem);
        IResult Update(CartItem cartItem);
        IDataResult<CartItem> AddOrUpdate(CartItem cartItem);
    }
}
