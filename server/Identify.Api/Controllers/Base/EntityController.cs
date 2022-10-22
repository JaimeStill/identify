using Identify.Models.Entities;
using Identify.Models.Query;
using Identify.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;
public abstract class EntityController<T> : SimpleEntityController<T> where T : Entity
{
    protected readonly IService<T> svc;

    public EntityController(IService<T> svc) : base(svc)
    {
        this.svc = svc;
    }

    [HttpGet("[action]")]
    public virtual async Task<IActionResult> Query([FromQuery]QueryParams queryParams) =>
        Ok(await svc.Query(queryParams));

    [HttpGet("[action]/{url}")]
    public virtual async Task<IActionResult> GetByUrl([FromRoute]string url) =>
        Ok(await svc.GetByUrl(url));
}