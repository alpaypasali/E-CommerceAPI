using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int PaymentId { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes PaymentType { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Address Address { get; set; }
        public Payment Payment { get; set; }

        public enum EnumOrderState
        {
            Waiting = 0,
            Unpaid = 1,
            Completed = 2
        }

        public enum EnumPaymentTypes
        {
            CreditCard = 0,
            Eft = 1
        }
    }
}