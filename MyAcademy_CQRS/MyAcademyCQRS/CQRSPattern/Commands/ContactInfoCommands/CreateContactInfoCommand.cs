namespace MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands
{
    public class CreateContactInfoCommand
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
        public string MapUrl { get; set; }
    }
}
