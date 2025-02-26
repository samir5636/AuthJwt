using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Stock;


public class CreatStockRequestDto
{
    [Required]
    [MaxLength(10, ErrorMessage = "Symbol length cannot be more than 10")]
    public string Symbole { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10, ErrorMessage = "CompanyName length cannot be more than 10")]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10, ErrorMessage = "Industry length cannot be more than 10")]
    public string Industry { get; set; } = string.Empty;
    
    [Required]
    [Range(0,10000000)]
    public decimal Purchase { get; set; }
    
    [Required]
    [Range(0.001,100)]
    public decimal LastDiv { get; set; }
    
    [Required]
    [MaxLength(10, ErrorMessage = "MarketCap length cannot be more than 10")]
    public long MarketCap { get; set; }
    
}