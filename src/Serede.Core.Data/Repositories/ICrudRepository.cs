using Serede.Core.Data.ContextDb;
using Serede.Core.Models;
using Serede.Core.Models.ViewModel;

namespace Serede.Core.Data.Repositories;

public interface ICrudRepository<T, S> : IRepository<T>, IDisposable
        where T : Model
        where S : Query
{
    void Adicionar(T entity);
    void Adicionar(List<T> entities);
    void Atualizar(T entity);
    void Atualizar(List<T> entities);
    void Remover(T Entity);
    void Remover(List<T> entities);
    Task<T> ObterPorId(object id);
    Task<IEnumerable<T>> ObterTodos(S seletor);

    IQueryable<T> MontarConsulta(S seletor, IQueryable<T> query);
    IQueryable<T> Limit(S seletor, IQueryable<T> query);
    IQueryable<T> Order(S seletor, IQueryable<T> query);    
}
