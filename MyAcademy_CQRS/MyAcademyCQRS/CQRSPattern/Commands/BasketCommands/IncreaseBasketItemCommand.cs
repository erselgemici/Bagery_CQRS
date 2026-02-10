
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class IncreaseBasketItemCommand 
    {
        public int Id { get; set; }
        public IncreaseBasketItemCommand(int id) { Id = id; }
    }
}
