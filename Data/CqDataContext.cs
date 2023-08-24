using CqrsDene.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsDene.Data;

public class CqDataContext : DbContext
{
    public CqDataContext(DbContextOptions<CqDataContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    DbSet<Person> People { get; set; }
}