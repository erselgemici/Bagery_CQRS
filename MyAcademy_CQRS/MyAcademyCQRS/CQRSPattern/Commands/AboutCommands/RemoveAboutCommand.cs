
namespace MyAcademyCQRS.CQRSPattern.Commands.AboutCommands
{
    public class RemoveAboutCommand 
    {
        public int Id { get; set; }
        public RemoveAboutCommand(int id) { Id = id; }
    }
}
