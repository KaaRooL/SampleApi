using Application.Dtos;
using Application.Queries;
using Common.Dispatcher.QueryProcessor;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers
{
    public class SampleQueryHandlerAsync : IQueryHandlerAsync<SampleQuery, BasicDto>
    {
        private readonly DataContext _dataContext;

        public SampleQueryHandlerAsync(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<BasicDto> HandleAsync(SampleQuery sample)
        {
            var canConnect = _dataContext.Database.CanConnect();
            var a = await _dataContext.Database.ExecuteSqlRawAsync("SELECT 1");
            return new BasicDto(canConnect.ToString());
        }
    }
    
    public class BasicQueryHandler : IQueryHandler<SampleQuery, BasicDto>
    {
        public BasicDto Handle(SampleQuery sample)
        {
            return new BasicDto();
        }
    }
}