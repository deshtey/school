using Microsoft.AspNetCore.Http;

namespace schoolapp.Application.Common.Models;
public class ProductDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal UnitCost { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal VatPercent { get; set; }
    public double Quantity { get; set; }
    public double ReorderLevel { get; set; }
    public string ModifiedBy { get; set; }
    public IFormFile? ImageFile { get; set; }
}
