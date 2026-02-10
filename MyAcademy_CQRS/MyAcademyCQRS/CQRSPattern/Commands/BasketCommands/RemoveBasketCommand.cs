
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class RemoveBasketCommand 
    {
        public int Id { get; set; }
        public RemoveBasketCommand(int id) { Id = id; }
    }
}
