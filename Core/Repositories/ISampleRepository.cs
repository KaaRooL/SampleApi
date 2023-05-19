namespace Core.Repositories;

public interface ISampleRepository
{
    Task<bool> DbAlive();
}