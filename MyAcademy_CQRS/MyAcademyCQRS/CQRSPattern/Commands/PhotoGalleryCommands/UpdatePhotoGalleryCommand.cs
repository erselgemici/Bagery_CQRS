namespace MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands
{
    public class UpdatePhotoGalleryCommand
    {
        public int PhotoGalleryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string FilterTag { get; set; }
    }
}
