namespace MyAcademyCQRS.CQRSPattern.Queries.BasketQueries
{
    public class GetBasketByIdQuery
    {
        public int Id { get; set; }
        public GetBasketByIdQuery(int id) { Id = id; }
    }
}
