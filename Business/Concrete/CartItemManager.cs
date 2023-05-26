using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public IDataResult<List<CartItem>> GetByCartId(int cartId)
        {
            return new SuccessDataResult<List<CartItem>>(_cartItemDal.GetAll(ci => ci.CartId == cartId));
        }

        public IDataResult<CartItem> GetById(int id)
        {
            return new SuccessDataResult<CartItem>(_cartItemDal.Get(ci => ci.Id == id));
        }

        public IResult Add(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
            return new SuccessResult("CartItem added successfully");
        }

        public IResult Delete(CartItem cartItem)
        {
            _cartItemDal.Delete(cartItem);
            return new SuccessResult("CartItem deleted successfully");
        }

        public IResult Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
            return new SuccessResult("CartItem updated successfully");
        }

        public IDataResult<CartItem> AddOrUpdate(CartItem cartItem)
        {
            var existingCartItem = _cartItemDal.Get(ci => ci.CartId == cartItem.CartId && ci.ProductId == cartItem.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartItem.Quantity;
                _cartItemDal.Update(existingCartItem);
                return new SuccessDataResult<CartItem>(existingCartItem, "CartItem quantity updated successfully.");
            }
            else
            {
                _cartItemDal.Add(cartItem);
                return new SuccessDataResult<CartItem>(cartItem, "CartItem added successfully.");
            }
        }
    }
}