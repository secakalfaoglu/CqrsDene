using CqrsDene.Models.Domain;

namespace CqrsDene.Repositories;

public interface IPeopleRepository
{
    public Task<List<Person>> GetAllAsync();
    public Task<Person?> GetByIdAsync(int id);
    public Task<Person> CreateAsync(Person person);
}