using System;

namespace MyAcademyCQRS.CQRSPattern.Commands.ContactCommands
{
    public class CreateContactCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
    }
}
