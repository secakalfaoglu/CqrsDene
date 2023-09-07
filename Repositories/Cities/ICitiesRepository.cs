using CqrsDene.Models.Domain;

namespace CqrsDene.Repositories;

public interface ICitiesRepository
{
    public Task<List<Cities>> GetAllAsync();
    
    public Task<Cities?> GetByIdAsync(int id);
    
    public Task<Cities> CreateAsync(Cities cities);
    
    public Task<Cities> DeleteAsync(Cities cities);
    
    public Task<Cities> UpdateAsync(Cities cities);
}