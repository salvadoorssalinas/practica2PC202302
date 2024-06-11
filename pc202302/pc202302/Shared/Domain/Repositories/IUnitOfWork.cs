namespace pc202302.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}