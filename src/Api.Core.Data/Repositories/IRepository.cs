using Api.Core.Data.ContextDb;
using Api.Core.Models.Models;

namespace Api.Core.Data.Repositories;

public interface IRepository<T> : IDisposable where T : Model
{
    IUnitOfWork UnitOfWork { get; }
}
