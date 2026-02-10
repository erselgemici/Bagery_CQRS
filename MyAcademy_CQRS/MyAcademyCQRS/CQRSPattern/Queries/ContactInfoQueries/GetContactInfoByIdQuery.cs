namespace MyAcademyCQRS.CQRSPattern.Queries.ContactInfoQueries
{
    public class GetContactInfoByIdQuery
    {
        public int Id { get; set; }
        public GetContactInfoByIdQuery(int id) { Id = id; }
    }
}
