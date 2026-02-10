using MyAcademyCQRS.CQRSPattern.Results.AboutResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.AboutQueries
{
    public class GetAboutByIdQuery 
    {
        public int Id { get; set; }
        public GetAboutByIdQuery(int id) { Id = id; }
    }
}
