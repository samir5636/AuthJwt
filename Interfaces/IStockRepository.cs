using backend.Dtos.Stock;
using backend.Models;

namespace backend.Interfaces;

public interface IStockRepository
{
    Task<List<Stocks>> GetAllAsync();
    Task<Stocks?> GetByIdAsync(int id);
    Task<Stocks> CreateAsync(Stocks stockModel);
    Task<Stocks?> UpdateAsync(int id, UpdateStockDto stockDto);
    Task<Stocks?> DeleteAsync(int id);
}