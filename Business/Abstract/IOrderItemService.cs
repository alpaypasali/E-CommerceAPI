using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        IDataResult<List<OrderItem>> GetByOrderId(int orderId);
        IDataResult<OrderItem> GetById(int id);
        IResult Add(OrderItem orderItem);
        IResult Delete(OrderItem orderItem);
        IResult Update(OrderItem orderItem);
        IDataResult<OrderItem> AddOrUpdate(OrderItem orderItem);
    }
}
