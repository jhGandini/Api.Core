using Api.Core.Models.Interfaces.Context;

namespace Api.Core.Models.Interfaces.Repositories;
public interface IAggregateRepository<T> : IDisposable where T : class
{
    IUnitOfWork UnitOfWork { get; }
}
