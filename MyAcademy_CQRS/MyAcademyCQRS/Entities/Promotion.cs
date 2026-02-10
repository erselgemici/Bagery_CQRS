namespace MyAcademyCQRS.Entities
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string Title { get; set; }      
        public string Description { get; set; }
        public decimal Price { get; set; }     
        public string ImageUrl { get; set; }
        public string ButtonUrl { get; set; }
    }
}
