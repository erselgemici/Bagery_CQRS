namespace MyAcademyCQRS.CQRSPattern.Results.PhotoGalleryResults
{
    public class GetPhotoGalleryByIdQueryResult
    {
        public int PhotoGalleryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string FilterTag { get; set; }
    }
}
