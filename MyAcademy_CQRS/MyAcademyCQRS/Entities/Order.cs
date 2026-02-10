using System;
using System.Collections.Generic;

namespace MyAcademyCQRS.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; } 
        public DateTime OrderDate { get; set; } 
        public List<OrderDetail> OrderDetails { get; set; } 
    }
}
