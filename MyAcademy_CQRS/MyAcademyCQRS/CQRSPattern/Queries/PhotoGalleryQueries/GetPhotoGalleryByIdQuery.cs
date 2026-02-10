namespace MyAcademyCQRS.CQRSPattern.Queries.PhotoGalleryQueries
{
    public class GetPhotoGalleryByIdQuery
    {
        public int Id { get; set; }
        public GetPhotoGalleryByIdQuery(int id) { Id = id; }
    }
}
