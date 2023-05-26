using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using static Entities.Concrete.Order;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private ICartService _cartService;

        public OrderManager(IOrderDal orderDal, ICartService cartService)
        {
            _orderDal = orderDal;
            _cartService = cartService;
        }

        public IDataResult<List<Order>> GetAll()
        {
            var orders = _orderDal.GetAll();

            if (orders == null || !orders.Any())
            {
                return new ErrorDataResult<List<Order>>("No orders found.");
            }

            return new SuccessDataResult<List<Order>>(orders, "Orders retrieved successfully.");
        }

        public IDataResult<Order> GetById(int id)
        {
            var order = _orderDal.Get(o => o.Id == id);

            if (order == null)
            {
                return new ErrorDataResult<Order>("Order not found.");
            }

            return new SuccessDataResult<Order>(order, "Order retrieved successfully.");
        }

        public IResult Add(Order order)
        {
            var cart = _cartService.GetCartByUserId(order.UserId).Data;

            if (cart == null || !cart.CartItems.Any())
            {
                return new ErrorResult("Cannot create an order with an empty cart.");
            }

            order.OrderDate = DateTime.Now;
            order.TotalAmount = cart.CartItems.Sum(ci => ci.Product.UnitPrice * ci.Quantity);

            _orderDal.Add(order);

            return new SuccessResult("Order added successfully.");
        }

        public IResult Delete(Order order)
        {
            var existingOrder = _orderDal.Get(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                return new ErrorResult("Order not found.");
            }

            _orderDal.Delete(existingOrder);

            return new SuccessResult("Order deleted successfully.");
        }

        public IResult Update(Order order)
        {
            var existingOrder = _orderDal.Get(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                return new ErrorResult("Order not found.");
            }

            _orderDal.Update(order);

            return new SuccessResult("Order updated successfully.");
        }

        public IDataResult<List<Order>> GetOrdersWithState(EnumOrderState orderState)
        {
            var result = _orderDal.GetAll(o => o.OrderState == orderState);
            return new SuccessDataResult<List<Order>>(result);
        }

        public IDataResult<List<Order>> GetOrdersWithPaymentType(EnumPaymentTypes paymentType)
        {
            var result = _orderDal.GetAll(o => o.PaymentType == paymentType);
            return new SuccessDataResult<List<Order>>(result);
        }
    }
}