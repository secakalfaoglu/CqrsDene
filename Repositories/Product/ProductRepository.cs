using CqrsDene.Data;
using CqrsDene.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsDene.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CqDbContext _dbContext;
    
    public ProductRepository(CqDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Product.ToListAsync();
    }
    
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _dbContext.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        var result = _dbContext.Product.Add(product);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
    
}