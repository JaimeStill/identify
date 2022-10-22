using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class MakeController : SimpleEntityController<Make>
{
    public MakeController(MakeService svc) : base(svc) { }
}