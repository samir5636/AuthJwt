using backend.Data;
using backend.Dtos.Comment;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/comments")]
[ApiController]

public class CommentController : ControllerBase
{

    readonly private ApplicationDbContext _dbContext;
    readonly private ICommentRepository _commentRepository;
    readonly private IStockRepository _stockRepository;

    public CommentController(ApplicationDbContext dbContext, ICommentRepository commentRepository, IStockRepository stockRepository)
    {
        _dbContext = dbContext;
        _commentRepository = commentRepository;
        _stockRepository = stockRepository;

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepository.GetAllAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment);
    }


    [HttpPost("{stockId}")]
    public async Task<IActionResult> Creat([FromRoute] int stockId, [FromBody] CreateCommentRequestDto createCommentDto){

        if (!await _stockRepository.StockExists(stockId))
        {
            return BadRequest("Stock does not exist");
        }
        var commentModel = createCommentDto.ToCommentsFromCreatDto(stockId);
        await _commentRepository.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        
    }
    
    
    [HttpPut("{id}")]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
    {
        var commentModel = await _commentRepository.UpdateAsync(id , updateCommentDto.ToCommentsFromUpdateDto());
        if (commentModel == null)
        {
            return NotFound();
        }
        return Ok(commentModel.ToCommentDto());
    }

    [HttpDelete("{id}")]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var commentModel = await _commentRepository.DeleteAsync(id);
        if (commentModel == null)
        {
            return NotFound();
        }
        
        return NoContent();
        
    }
    
    
    
    

}