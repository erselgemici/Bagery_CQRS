namespace MyAcademyCQRS.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int UserId { get; set; } 
        public List<BasketItem> BasketItems { get; set; }
    }
}
