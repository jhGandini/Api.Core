namespace Serede.Core.Data.ContextDb;

public interface IUnitOfWork
{
    Task<bool> Commit();
}