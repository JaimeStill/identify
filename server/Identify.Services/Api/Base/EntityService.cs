using Identify.Data;
using Identify.Models.Entities;
using Identify.Models.Query;
using Identify.Services.Exceptions;
using Identify.Services.Extensions;
using Identify.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identify.Services.Api;
public abstract class EntityService<T> : SimpleEntityService<T>, IService<T> where T : Entity
{
    protected IQueryable<T> query;

    public EntityService(AppDbContext db) : base(db)
    {
        query = SetGraph(db.Set<T>());
    }

    protected override async Task<T> Update(T entity)
    {
        try
        {
            ClearGraph(entity);
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new ServiceException<T>("Update", ex);
        }
    }

    public override async Task<T> GetById(int id) =>
        await query.FirstOrDefaultAsync(x => x.Id == id);

    public override async Task<int> Remove(T entity)
    {
        try
        {
            ClearGraph(entity);
            db.Set<T>().Remove(entity);
            int result = await db.SaveChangesAsync();

            return result > 0
                ? entity.Id
                : 0;
        }
        catch (Exception ex)
        {
            throw new ServiceException<T>("Remove", ex);
        }
    }

    protected virtual Func<IQueryable<T>, string, IQueryable<T>> Search =>
        (values, term) =>
            values.Where(x =>
                x.Name.ToLower().Contains(term.ToLower())
            );

    protected virtual void ClearGraph(T entity)
    {
        return;
    }

    protected virtual IQueryable<T> SetGraph(DbSet<T> data) =>
        data;

    protected virtual async Task<QueryResult<E>> Query<E>(
        IQueryable<E> queryable,
        QueryParams queryParams,
        Func<IQueryable<E>, string, IQueryable<E>> search
    ) where E : Entity
    {
        var container = new QueryContainer<E>(
            queryable,
            queryParams
        );

        return await container.Query((data, s) =>
            data.SetupSearch(s, search)
        );
    }

    protected virtual async Task<List<E>> Get<E>(
        IQueryable<E> queryable,
        string sort = "Name"
    ) where E : Entity =>
        await queryable
            .ApplySorting(new QueryOptions { Sort = sort })
            .ToListAsync();

    public virtual async Task<QueryResult<T>> Query(QueryParams queryParams) =>
        await Query(
            query, queryParams, Search
        );

    public virtual async Task<T> GetByUrl(string url) =>
        await query.FirstOrDefaultAsync(x => x.Url.ToLower() == url.ToLower());
}