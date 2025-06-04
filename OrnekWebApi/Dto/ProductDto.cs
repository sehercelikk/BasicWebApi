namespace OrnekWebApi.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}