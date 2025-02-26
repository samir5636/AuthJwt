using backend.Data;
using backend.Dtos.Stock;
using backend.Helpers;
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
    public async Task<List<Stocks>> GetAllAsync(QueryObject query)
    {
        var stocks =  _context.Stocks.Include(c => c.Comments).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.CompanyName))
        {
            stocks = stocks.Where(c => c.CompanyName.ToLower().Contains(query.CompanyName.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(query.Symbole))
        {
            stocks = stocks.Where(s => s.Symbole.ToLower().Contains(query.Symbole.ToLower()));
        }

        if (query.SortBy.Equals("Symbole", StringComparison.OrdinalIgnoreCase))
        {
            stocks = query.IsDescending ? stocks.OrderByDescending(c => c.Symbole) : stocks.OrderBy(c => c.Symbole);
        }
        
        var SkipNumber = (query.PageNumber - 1) * query.PageSize;
        
        return await stocks.Skip(SkipNumber).Take(query.PageSize).ToListAsync();
        
        
        
    }

    public async Task<Stocks?> GetByIdAsync(int id)
    {
        return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);

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

    public Task<bool> StockExists(int id)
    {
        return _context.Stocks.AnyAsync(x => x.Id == id);
    }
}