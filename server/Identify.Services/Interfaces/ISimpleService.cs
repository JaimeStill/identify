using Identify.Models.Entities;
using Identify.Models.Validation;

namespace Identify.Services.Interfaces;
public interface ISimpleService<T> where T : SimpleEntity
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<bool> ValidateName(T entity);
    Task<ValidationResult> Validate(T entity);
    Task<T> Save(T entity);
    Task<int> Remove(T entity);
}