using System;

namespace MyAcademyCQRS.CQRSPattern.Results.LogResults
{
    public class GetLogQueryResult
    {
        public int LogId { get; set; }
        public string Message { get; set; }
        public string Section { get; set; } 
        public DateTime Date { get; set; }
        public string Detail { get; set; }
    }
}
