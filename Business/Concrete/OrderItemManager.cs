using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public IDataResult<List<OrderItem>> GetByOrderId(int orderId)
        {
            var result = _orderItemDal.GetAll(oi => oi.OrderId == orderId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<OrderItem>>($"No order items found for order id: {orderId}");
            }

            return new SuccessDataResult<List<OrderItem>>(result);
        }

        public IDataResult<OrderItem> GetById(int id)
        {
            var result = _orderItemDal.Get(oi => oi.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<OrderItem>($"No order item found with id: {id}");
            }

            return new SuccessDataResult<OrderItem>(result);
        }

        public IResult Add(OrderItem orderItem)
        {
            try
            {
                _orderItemDal.Add(orderItem);
                return new SuccessResult("OrderItem added successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Failed to add order item: {ex.Message}");
            }
        }

        public IResult Delete(OrderItem orderItem)
        {
            try
            {
                _orderItemDal.Delete(orderItem);
                return new SuccessResult("OrderItem deleted successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Failed to delete order item: {ex.Message}");
            }
        }

        public IResult Update(OrderItem orderItem)
        {
            try
            {
                _orderItemDal.Update(orderItem);
                return new SuccessResult("OrderItem updated successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Failed to update order item: {ex.Message}");
            }
        }

        public IDataResult<OrderItem> AddOrUpdate(OrderItem orderItem)
        {
            var existingOrderItem = _orderItemDal.Get(oi => oi.OrderId == orderItem.OrderId && oi.ProductId == orderItem.ProductId);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += orderItem.Quantity;
                _orderItemDal.Update(existingOrderItem);
                return new SuccessDataResult<OrderItem>(existingOrderItem, "OrderItem quantity updated successfully.");
            }
            else
            {
                _orderItemDal.Add(orderItem);
                return new SuccessDataResult<OrderItem>(orderItem, "OrderItem added successfully.");
            }
        }
    }
}