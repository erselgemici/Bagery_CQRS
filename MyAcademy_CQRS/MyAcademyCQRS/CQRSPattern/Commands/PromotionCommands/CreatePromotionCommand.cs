namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands
{
    public class CreatePromotionCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonUrl { get; set; }
    }
}
