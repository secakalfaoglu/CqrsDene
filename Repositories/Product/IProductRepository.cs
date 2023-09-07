using CqrsDene.Models.Domain;

namespace CqrsDene.Repositories;

public interface IProductRepository
{
    public Task<List<Product>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task<Product> CreateAsync(Product product);
}