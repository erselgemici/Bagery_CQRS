namespace MyAcademyCQRS.CQRSPattern.Commands.NewsCommands
{
    public class RemoveNewsCommand
    {
        public int Id { get; set; }
        public RemoveNewsCommand(int id) { Id = id; }
    }
}
