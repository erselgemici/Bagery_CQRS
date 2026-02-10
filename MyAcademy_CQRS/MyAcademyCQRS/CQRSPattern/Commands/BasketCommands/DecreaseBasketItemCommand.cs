
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class DecreaseBasketItemCommand 
    {
        public int Id { get; set; }
        public DecreaseBasketItemCommand(int id) { Id = id; }
    }
}
