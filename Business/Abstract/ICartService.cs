using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {

        IDataResult<Cart> GetCartByUserId(int userId);
        IDataResult<List<Cart>> GetAllCarts();
        IResult AddToCart(CartItem cartItem);
        IResult RemoveFromCart(CartItem cartItem);
        IResult UpdateCart(Cart cart);
        IResult ClearCart(int cartId);
    }
}
