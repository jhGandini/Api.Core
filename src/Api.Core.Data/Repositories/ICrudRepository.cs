using Api.Core.Models.Models;
using Api.Core.Models.ViewModel;

namespace Api.Core.Data.Repositories;

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
