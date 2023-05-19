using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }
}

