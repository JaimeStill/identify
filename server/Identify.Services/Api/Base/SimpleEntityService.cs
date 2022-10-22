using Identify.Data;
using Identify.Models.Entities;
using Identify.Models.Validation;
using Identify.Services.Exceptions;
using Identify.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identify.Services.Api;
public abstract class SimpleEntityService<T> : ISimpleService<T> where T : SimpleEntity
{
    protected AppDbContext db;

    public SimpleEntityService(AppDbContext db)
    {
        this.db = db;
    }

    protected virtual async Task<T> Add(T entity)
    {
        try
        {
            await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new ServiceException<T>("Add", ex);
        }
    }

    protected virtual async Task<T> Update(T entity)
    {
        try
        {
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new ServiceException<T>("Update", ex);
        }
    }

    public virtual async Task<List<T>> GetAll() =>
        await db.Set<T>()
            .OrderBy(x => x.Name)
            .ToListAsync();

    public virtual async Task<T> GetById(int id) =>
        await db.Set<T>().FindAsync(id);    

    public virtual async Task<bool> ValidateName(T entity) =>
        !await db.Set<T>().AnyAsync(x =>
            x.Id != entity.Id
            && x.Name.ToLower() == entity.Name.ToLower()
        );

    public virtual async Task<ValidationResult> Validate(T entity)
    {
        ValidationResult result = new();

        if (string.IsNullOrWhiteSpace(entity.Name))
            result.AddMessage("Name is required");

        if (!await ValidateName(entity))
            result.AddMessage("Name is already in use");

        return result;
    }

    public virtual async Task<T> Save(T entity)
    {
        try
        {
            var validity = await Validate(entity);

            if (validity.IsValid)
                return entity.Id > 0
                    ? await Update(entity)
                    : await Add(entity);
            else
                throw new ServiceException<T>("Save", new Exception(validity.Message));
        }
        catch(Exception ex)
        {
            throw new ServiceException<T>("Save", ex);
        }
    }

    public virtual async Task<int> Remove(T entity)
    {
        try
        {
            db.Set<T>().Remove(entity);
            int result = await db.SaveChangesAsync();

            return result > 0
                ? entity.Id
                : 0;
        }
        catch(Exception ex)
        {
            throw new ServiceException<T>("Remove", ex);
        }
    }
}