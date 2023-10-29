namespace Api.Core.Models.Interfaces;
public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    bool Commit();
}
