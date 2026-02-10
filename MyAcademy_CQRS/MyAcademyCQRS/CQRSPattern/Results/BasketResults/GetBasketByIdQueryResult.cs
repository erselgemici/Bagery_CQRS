namespace MyAcademyCQRS.CQRSPattern.Results.BasketResults
{
    public class GetBasketByIdQueryResult
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int BasketId { get; set; }
    }
}
