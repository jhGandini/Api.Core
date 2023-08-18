namespace Api.Core.Data.ContextDb;

public interface IUnitOfWork
{
    Task<bool> Commit();
}