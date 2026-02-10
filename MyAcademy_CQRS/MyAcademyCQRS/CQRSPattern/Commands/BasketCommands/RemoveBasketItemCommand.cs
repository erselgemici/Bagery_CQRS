
namespace MyAcademyCQRS.CQRSPattern.Commands.BasketCommands
{
    public class RemoveBasketItemCommand 
    {
        public int Id { get; set; } // Silinecek BasketItem ID'si

        public RemoveBasketItemCommand(int id)
        {
            Id = id;
        }
    }
}
