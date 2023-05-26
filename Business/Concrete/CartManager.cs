using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;

        private ICartItemDal _cartItemDal;

        public CartManager(ICartDal cartDal, ICartItemDal cartItemDal)
        {
            _cartDal = cartDal;
            _cartItemDal = cartItemDal;
        }

        public IDataResult<Cart> GetCartByUserId(int userId)
            {
                var cart = _cartDal.Get(c => c.UserId == userId);
                if (cart == null)
                {
                    return new ErrorDataResult<Cart>("Cart not found.");
                }

                return new SuccessDataResult<Cart>(cart, "Cart retrieved successfully.");
            }

            public IDataResult<List<Cart>> GetAllCarts()
            {
                var carts = _cartDal.GetAll();

                if (carts == null || !carts.Any())
                {
                    return new ErrorDataResult<List<Cart>>("No carts found.");
                }

                return new SuccessDataResult<List<Cart>>(carts, "Carts retrieved successfully.");
            }

             public IResult AddToCart(CartItem cartItem)
        {
            var cart = _cartDal.Get(c => c.Id == cartItem.CartId);
            if (cart == null)
            {
                return new ErrorResult("Cart not found.");
            }

            _cartItemDal.Add(cartItem); // Here is the corrected part
            return new SuccessResult("Product added to cart successfully.");
            }

        public IResult RemoveFromCart(CartItem cartItem)
        {
            var cartItemExists = _cartItemDal.Get(ci => ci.Id == cartItem.Id); // Here is the corrected part
            if (cartItemExists == null)
            {
                return new ErrorResult("Cart item not found.");
            }

            _cartItemDal.Delete(cartItem); // Here is the corrected part
            return new SuccessResult("Product removed from cart successfully.");
        }


        public IResult UpdateCart(Cart cart)
            {
                var existingCart = _cartDal.Get(c => c.Id == cart.Id);
                if (existingCart == null)
                {
                    return new ErrorResult("Cart not found.");
                }

                _cartDal.Update(cart);
                return new SuccessResult("Cart updated successfully.");
            }

            public IResult ClearCart(int cartId)
            {
                var cart = _cartDal.Get(c => c.Id == cartId);
                if (cart == null)
                {
                    return new ErrorResult("Cart not found.");
                }

                _cartDal.Delete(cart);
                return new SuccessResult("Cart cleared successfully.");
            }
     }
}
