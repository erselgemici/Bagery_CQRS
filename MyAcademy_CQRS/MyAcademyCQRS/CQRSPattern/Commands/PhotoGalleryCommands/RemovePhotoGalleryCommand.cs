namespace MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands
{
    public class RemovePhotoGalleryCommand
    {
        public int Id { get; set; }
        public RemovePhotoGalleryCommand(int id) { Id = id; }
    }
}
