using backend.Data;
using backend.Dtos.Stock;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
       _context = context; 
    }
    public async Task<List<Stocks>> GetAllAsync()
    {
        return await _context.Stocks.ToListAsync();
        
    }

    public async Task<Stocks?> GetByIdAsync(int id)
    {
        return await _context.Stocks.FindAsync(id);

    }

    public async Task<Stocks> CreateAsync(Stocks stockModel)
    {
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stocks?> UpdateAsync(int id, UpdateStockDto stockDto)
    {
        var existingStock = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

        if (existingStock == null)
        {
            return null;
        }
        
        existingStock.Symbole = stockDto.Symbole;
        existingStock.CompanyName = stockDto.CompanyName;
        existingStock.Industry = stockDto.Industry;
        existingStock.Purchase  = stockDto.Purchase;
        existingStock.LastDiv = stockDto.LastDiv;
        existingStock.MarketCap = stockDto.MarketCap;
        
        await _context.SaveChangesAsync();
        return existingStock;
    }

    public async Task<Stocks?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null)
        {
            return null;
        }
        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }
}