
namespace MyAcademyCQRS.CQRSPattern.Commands.AboutCommands
{
    public class CreateAboutCommand 
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string SignatureUrl { get; set; }
    }
}
