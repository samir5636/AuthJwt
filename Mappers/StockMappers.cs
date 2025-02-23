using backend.Dtos.Stock;
using backend.Models;

namespace backend.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stocks StockModel)
    {
        return new StockDto
        {
            Id = StockModel.Id,
            Symbole = StockModel.Symbole,
            CompanyName = StockModel.CompanyName,
            Industry = StockModel.Industry,
            Purchase = StockModel.Purchase,
            LastDiv = StockModel.LastDiv,
            MarketCap = StockModel.MarketCap,
        };
    }

    public static Stocks ToStockFromCreateDto(this CreatStockRequestDto StockDto)
    {
        return new Stocks
        {
            Symbole = StockDto.Symbole,
            CompanyName = StockDto.CompanyName,
            Industry = StockDto.Industry,
            Purchase = StockDto.Purchase,
            LastDiv = StockDto.LastDiv,
            MarketCap = StockDto.MarketCap,
        };
    }
    
}