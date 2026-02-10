
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class CreateBasketItemCommand 
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
