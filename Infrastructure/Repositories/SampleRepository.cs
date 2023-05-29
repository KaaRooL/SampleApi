using Core.Repositories;
using Infrastructure.EntityFramework;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class SampleRepository : ISampleRepository
{
    private readonly DataContext _context;
    private readonly ILogger<SampleRepository> _logger;
    public SampleRepository(DataContext context, ILogger<SampleRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> DbAlive()
    {
        _logger.LogInformation("Hello");
        return await _context.Database.CanConnectAsync();
    }
}