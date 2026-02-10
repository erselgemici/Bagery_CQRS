using System;

namespace MyAcademyCQRS.CQRSPattern.Results.OrderResults
{
    public class GetOrderQueryResult
    {
        public int OrderId { get; set; }
        public int UserId { get; set; } 
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
