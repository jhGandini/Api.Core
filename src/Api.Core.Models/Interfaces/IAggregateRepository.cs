namespace Api.Core.Models.Interfaces;
public interface IAggregateRepository<T> : IDisposable where T : class
{
    IUnitOfWork UnitOfWork { get; }
}
