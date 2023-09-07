using CqrsDene.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsDene.Data;

public class CqDbContext : DbContext
{
    public CqDbContext(DbContextOptions<CqDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Product> Product { get; set; }
    
    public DbSet<Cities> Cities { get; set; }
}