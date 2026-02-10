using MyAcademyCQRS.CQRSPattern.Results.BasketResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.BasketQueries
{
    public class GetBasketByUserIdQuery 
    {
        public int UserId { get; set; }
    }
}
