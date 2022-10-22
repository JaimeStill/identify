using Identify.Models.Entities;
using Identify.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;
public abstract class SimpleEntityController<T> : ControllerBase where T : SimpleEntity
{
    protected readonly ISimpleService<T> simpleSvc;

    public SimpleEntityController(ISimpleService<T> simpleSvc)
    {
        this.simpleSvc = simpleSvc;
    }

    [HttpGet("[action]")]
    public virtual async Task<IActionResult> GetAll() =>
        Ok(await simpleSvc.GetAll());

    [HttpGet("[action]/{id:int}")]
    public virtual async Task<IActionResult> GetById([FromRoute]int id) =>
        Ok(await simpleSvc.GetById(id));

    [HttpPost("[action]")]
    public virtual async Task<IActionResult> ValidateName([FromBody]T entity) =>
        Ok(await simpleSvc.ValidateName(entity));

    [HttpPost("[action]")]
    public virtual async Task<IActionResult> Validate([FromBody]T entity) =>
        Ok(await simpleSvc.Validate(entity));

    [HttpPost("[action]")]
    public virtual async Task<IActionResult> Save([FromBody]T entity) =>
        Ok(await simpleSvc.Save(entity));

    [HttpDelete("[action]")]
    public virtual async Task<IActionResult> Remove([FromBody]T entity) =>
        Ok(await simpleSvc.Remove(entity));
}