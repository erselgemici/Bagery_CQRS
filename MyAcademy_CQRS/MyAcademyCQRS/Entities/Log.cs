using System;

namespace MyAcademyCQRS.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string Message { get; set; } 
        public string Section { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
    }
}
