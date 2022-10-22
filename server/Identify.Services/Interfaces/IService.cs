using Identify.Models.Entities;
using Identify.Models.Query;

namespace Identify.Services.Interfaces;
public interface IService<T> : ISimpleService<T> where T : Entity
{
    Task<QueryResult<T>> Query(QueryParams queryParams);
    Task<T> GetByUrl(string url);
}