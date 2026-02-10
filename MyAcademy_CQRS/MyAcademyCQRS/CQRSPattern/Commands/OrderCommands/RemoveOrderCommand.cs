namespace MyAcademyCQRS.CQRSPattern.Commands.OrderCommands
{
    public class RemoveOrderCommand
    {
        public int Id { get; set; }
        public RemoveOrderCommand(int id) { Id = id; }
    }
}
