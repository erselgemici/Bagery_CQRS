namespace MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands
{
    public class RemoveContactInfoCommand
    {
        public int Id { get; set; }
        public RemoveContactInfoCommand(int id) { Id = id; }
    }
}
