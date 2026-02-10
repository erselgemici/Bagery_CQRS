namespace MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries
{
    public class GetPromotionByIdQuery
    {
        public int Id { get; set; }
        public GetPromotionByIdQuery(int id) { Id = id; }
    }
}
