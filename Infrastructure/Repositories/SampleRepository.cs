using Core.Repositories;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories;

public class SampleRepository : ISampleRepository
{
    private readonly DataContext _context;

    public SampleRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> DbAlive()
    {
        return await _context.Database.CanConnectAsync();
    }
}