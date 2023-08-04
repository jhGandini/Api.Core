namespace Serede.CoreApi.ContextDb;

public interface IUnitOfWork
{
    Task<bool> Commit();
}