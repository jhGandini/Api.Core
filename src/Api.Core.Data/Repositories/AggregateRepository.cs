using Api.Core.Data.ContextDb;
using Api.Core.Models.Interfaces.Context;
using Api.Core.Models.Interfaces.Repositories;
using Api.Core.Models.Models;
using Api.Core.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Core.Data.Repositories;

public abstract class AggregateRepository<T> : IAggregateRepository<T> where T : class
{
    protected readonly Context _context;
    protected readonly DbSet<T> _dbSet;

    public AggregateRepository(Context context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Dispose() => _context?.Dispose();
    public IUnitOfWork UnitOfWork => _context;

    public virtual void AttachModify(T entity) => _context.Attach(entity).State = EntityState.Modified;

    protected virtual IQueryable<T> Track(IQueryable<T> table, bool track) => !track ? table.AsNoTracking() : table;
    protected virtual IQueryable<TM> Track<TM>(IQueryable<TM> table, bool track) where TM : Model => !track ? table.AsNoTracking() : table;

    protected virtual IQueryable<T> Limit(BaseParams sel, IQueryable<T> query)
    {
        if (!sel.Limit.Equals(0))
        {
            sel.Page = sel.Page.Equals(0) ? 1 : sel.Page;
            query = query.Skip((sel.Page - 1) * sel.Limit).Take(sel.Limit);
        }
        return query;
    }

    protected virtual IQueryable<TM> Limit<TM>(BaseParams sel, IQueryable<TM> query) where TM : Model
    {
        if (!sel.Limit.Equals(0))
        {
            sel.Page = sel.Page.Equals(0) ? 1 : sel.Page;
            query = query.Skip((sel.Page - 1) * sel.Limit).Take(sel.Limit);
        }
        return query;
    }

    protected virtual IQueryable<TM> Order<TM>(BaseParams seletor, IQueryable<TM> query) where TM : Model
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
                query = (IQueryable<TM>)query.Provider.CreateQuery(Expression.Call(typeof(Queryable), orderBy,
                    new Type[] { query.ElementType, exp.Body.Type }, query.Expression, exp));
            }
        }

        return query;
    }

    protected virtual IQueryable<T> Order(BaseParams seletor, IQueryable<T> query)
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
}
