namespace MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands
{
    public class CreatePhotoGalleryCommand
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string FilterTag { get; set; }
        public IFormFile Photo { get; set; }
    }
}
