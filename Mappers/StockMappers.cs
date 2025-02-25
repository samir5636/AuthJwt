using backend.Dtos.Stock;
using backend.Models;

namespace backend.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stocks stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbole = stockModel.Symbole,
            CompanyName = stockModel.CompanyName,
            Industry = stockModel.Industry,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c=> c.ToCommentDto()).ToList(),
        };
    }

    public static Stocks ToStockFromCreateDto(this CreatStockRequestDto stockDto)
    {
        return new Stocks
        {
            Symbole = stockDto.Symbole,
            CompanyName = stockDto.CompanyName,
            Industry = stockDto.Industry,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            MarketCap = stockDto.MarketCap,
        };
    }
    
}