namespace MyAcademyCQRS.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }
}
