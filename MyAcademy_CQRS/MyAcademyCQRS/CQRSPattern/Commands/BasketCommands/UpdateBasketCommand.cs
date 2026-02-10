
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class UpdateBasketCommand 
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
    }
}
