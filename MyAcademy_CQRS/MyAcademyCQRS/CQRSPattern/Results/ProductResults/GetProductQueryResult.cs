using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Results.ProductResults;
public class GetProductQueryResult
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public string ImageUrl { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }

    public string CategoryName { get; set; }
}

