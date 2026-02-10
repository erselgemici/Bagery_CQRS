namespace MyAcademyCQRS.CQRSPattern.Results.SliderResults
{
    public class GetSliderByIdQueryResult
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonUrl { get; set; }
    }
}
