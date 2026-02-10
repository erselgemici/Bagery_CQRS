using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Commands.OrderCommands
{
    public class CreateOrderCommand
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
