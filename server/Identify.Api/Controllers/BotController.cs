using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class BotController : EntityController<Bot>
{
    public BotController(BotService svc) : base(svc) { }
}