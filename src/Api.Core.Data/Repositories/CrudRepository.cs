using Api.Core.Data.ContextDb;
using Api.Core.Models.Interfaces;
using Api.Core.Models.Models;
using Api.Core.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Core.Data.Repositories;

public abstract class CrudRepository<T, S> : ICrudRepository<T, S>
        where T : Model
        where S : BaseParams
{
    protected readonly Context _context;

    protected CrudRepository(Context context) => _context = context;

    public IUnitOfWork UnitOfWork => _context;

    protected virtual IQueryable<T> CreateQuery() => _context.Set<T>().AsNoTracking().AsQueryable();

    public virtual void Adicionar(T entity) => _context.Set<T>().Add(entity);

    public virtual void Adicionar(List<T> entities) => _context.Set<T>().AddRange(entities);

    public virtual void Atualizar(T entity) => _context.Set<T>().Update(entity);

    public virtual void Atualizar(List<T> entities) => _context.Set<T>().UpdateRange(entities);

    public virtual void Remover(T Entity) => _context.Remove(Entity);
    public virtual void Remover(List<T> entities) => _context.RemoveRange(entities);

    public abstract Task<T> ObterPorId(object id);

    public virtual async Task<IEnumerable<T>> ObterTodos(S seletor)
    {
        var query = MontarConsulta(seletor, CreateQuery());
        return await query.ToListAsync();
    }


    public virtual IQueryable<T> MontarConsulta(S seletor, IQueryable<T> query) => throw new NotImplementedException();
    public virtual IQueryable<T> Limit(S sel, IQueryable<T> query)
    {
        if (!sel.Limit.Equals(0))
        {
            sel.Page = sel.Page.Equals(0) ? 1 : sel.Page;
            query = query.Skip((sel.Page - 1) * sel.Limit).Take(sel.Limit);
        }
        return query;
    }

    public virtual IQueryable<T> Order(S seletor, IQueryable<T> query)
    {
        if (!string.IsNullOrEmpty(seletor.OrderBy))
        {
            query = query.OrderBy(y => 1);
            string[] fields = seletor.OrderBy.Split(',');
            foreach (string fieldWithOrder in fields)
            {
                string[] fieldParam = fieldWithOrder.Split(' ');
                string orderBy = "ThenBy";
                if (seletor.OrderByOrder.ToUpper().Equals("DESC"))
                {
                    orderBy = "ThenByDescending";
                }
                ParameterExpression x = Expression.Parameter(query.ElementType, "x");
                LambdaExpression exp = Expression.Lambda(Expression.PropertyOrField(x, fieldParam[0].Trim()), x);
                query = (IQueryable<T>)query.Provider.CreateQuery(Expression.Call(typeof(Queryable), orderBy,
                    new Type[] { query.ElementType, exp.Body.Type }, query.Expression, exp));
            }
        }

        return query;
    }


    public void Dispose() => _context?.Dispose();
}
