using backend.Data;
using backend.Dtos.Stock;
using backend.Helpers;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/stock")]
[ApiController]  
public class StockController:ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockRepository;
    public StockController(ApplicationDbContext context, IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
        _context = context;
        
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stocks = await _stockRepository.GetAllAsync(query);
        var stockDto = stocks.Select(s=>s.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stock = await _stockRepository.GetByIdAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatStockRequestDto stockDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var StockModel = stockDto.ToStockFromCreateDto();
        
        await _stockRepository.CreateAsync(StockModel);
        return CreatedAtAction(nameof(GetById), new { id = StockModel.Id }, StockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = await _stockRepository.UpdateAsync(id, updateStockDto);

        if (stockModel == null)
        {
            return NotFound();
        }
        
        return Ok(stockModel.ToStockDto());

    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = await _stockRepository.DeleteAsync(id);

        if (stockModel == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    

}