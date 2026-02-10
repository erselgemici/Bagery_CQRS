namespace MyAcademyCQRS.CQRSPattern.Commands.ProductCommands
{
    public class RemoveProductCommand
    {
        public int Id { get; set; }
        public RemoveProductCommand(int id) { Id = id; }
    }
}
