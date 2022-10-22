using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class BotColorController : SimpleEntityController<BotColor>
{
    public BotColorController(BotColorService svc) : base(svc)
    { }
}