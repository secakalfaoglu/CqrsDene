using CqrsDene.Data;
using CqrsDene.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsDene.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private readonly CqDbContext _dbContext;

    public PeopleRepository(CqDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Person>> GetAllAsync()
    {
        return await _dbContext.People.ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _dbContext.People.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Person> CreateAsync(Person person)
    {
        var result = _dbContext.People.Add(person);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
}