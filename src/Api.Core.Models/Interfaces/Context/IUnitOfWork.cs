namespace Api.Core.Models.Interfaces.Context;
public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    bool Commit();
}
