namespace MyAcademyCQRS.CQRSPattern.Queries.LogQueries
{
    public class GetLogQuery
    {
        public string SearchKey { get; set; }

        public GetLogQuery(string searchKey = null)
        {
            SearchKey = searchKey;
        }
    }
}
