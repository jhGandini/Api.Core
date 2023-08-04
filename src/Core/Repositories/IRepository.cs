using Serede.CoreApi.ContextDb;

namespace Serede.CoreApi.Repositories;

public interface IRepository<T> : IDisposable where T : Model.Model
{
    IUnitOfWork UnitOfWork { get; }
}
