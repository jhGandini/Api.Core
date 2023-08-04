using Serede.CoreApi.ContextDb;
using Serede.CoreApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Serede.CoreApi.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Model.Model
{
    protected readonly Context _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(Context context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Dispose() => _context?.Dispose();
    public IUnitOfWork UnitOfWork => _context;
    protected IQueryable<T> Track(IQueryable<T> table, bool track) => !track ? table.AsNoTracking() : table;
    protected IQueryable<TM> Track<TM>(IQueryable<TM> table, bool track) where TM : Model.Model => !track ? table.AsNoTracking() : table;

    protected virtual IQueryable<T> Limit(Query sel, IQueryable<T> query)
    {
        if (!sel.Limit.Equals(0))
        {
            sel.Page = sel.Page.Equals(0) ? 1 : sel.Page;
            query = query.Skip((sel.Page - 1) * sel.Limit).Take(sel.Limit);
        }
        return query;
    }

    protected virtual IQueryable<T> Order(Query seletor, IQueryable<T> query)
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
