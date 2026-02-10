namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands
{
    public class RemovePromotionCommand
    {
        public int Id { get; set; }
        public RemovePromotionCommand(int id) { Id = id; }
    }
}
