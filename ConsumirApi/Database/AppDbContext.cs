using Microsoft.EntityFrameworkCore;

namespace ConsumirApi.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}