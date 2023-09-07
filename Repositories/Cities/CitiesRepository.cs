using CqrsDene.Data;
using CqrsDene.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsDene.Repositories;

public class CitiesRepository: ICitiesRepository
{
    
    private readonly CqDbContext _dbContext;
    
    public CitiesRepository(CqDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Cities>> GetAllAsync()
    {
        return await _dbContext.Cities.ToListAsync();
    }
    
    public async Task<Cities?> GetByIdAsync(int id)
    {
        return await _dbContext.Cities.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<Cities> CreateAsync(Cities cities)
    {
        var result = _dbContext.Cities.Add(cities);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<Cities> DeleteAsync(Cities cities)
    {
        var result = _dbContext.Cities.Remove(cities);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<Cities> UpdateAsync(Cities cities)
    {
        var result = _dbContext.Cities.Update(cities);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
    
}