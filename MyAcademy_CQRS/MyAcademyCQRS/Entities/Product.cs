namespace MyAcademyCQRS.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }         

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<BasketItem> BasketItems { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
