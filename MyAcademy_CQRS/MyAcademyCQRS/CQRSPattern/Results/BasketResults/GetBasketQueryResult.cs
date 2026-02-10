namespace MyAcademyCQRS.CQRSPattern.Results.BasketResults
{
    public class GetBasketQueryResult
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalRowPrice => Quantity * Price;
    }
}
