﻿using backend.Dtos.Comment;

namespace backend.Dtos.Stock;

public class StockDto
{
    public int Id { get; set; }

    public string Symbole { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    
    public decimal Purchase { get; set; }

    public decimal LastDiv { get; set; }

    public long MarketCap { get; set; }
    
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    
}