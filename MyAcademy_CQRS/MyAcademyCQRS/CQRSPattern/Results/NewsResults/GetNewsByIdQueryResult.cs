using System;

namespace MyAcademyCQRS.CQRSPattern.Results.NewsResults
{
    public class GetNewsByIdQueryResult
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
    }
}
