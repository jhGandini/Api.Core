using Serede.Core.Data.ContextDb;
using Serede.Core.Models;

namespace Serede.Core.Data.Repositories;

public interface IRepository<T> : IDisposable where T : Model
{
    IUnitOfWork UnitOfWork { get; }
}
