using backend.Data;
using backend.Dtos.Stock;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/stock")]
[ApiController]  
public class StockController:ControllerBase
{
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context)
    {
        _context = context;
        
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _context.Stocks.ToListAsync();
        var stockDto = stocks.Select(s=>s.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatStockRequestDto stockDto)
    {
        var StockModel = stockDto.ToStockFromCreateDto();
        
        await _context.Stocks.AddAsync(StockModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = StockModel.Id }, StockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stockModel == null)
        {
            return NotFound();
        }
        
        stockModel.Symbole = updateStockDto.Symbole;
        stockModel.CompanyName = updateStockDto.CompanyName;
        stockModel.Industry = updateStockDto.Industry;
        stockModel.Purchase  = updateStockDto.Purchase;
        stockModel.LastDiv = updateStockDto.LastDiv;
        stockModel.MarketCap = updateStockDto.MarketCap;

        await _context.SaveChangesAsync();
        
        return Ok(stockModel.ToStockDto());

    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stockModel == null)
        {
            return NotFound();
        }
        
        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    

}