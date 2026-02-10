
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class CreateBasketCommand 
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
