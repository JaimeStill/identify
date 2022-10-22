using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class AdventurerController : EntityController<Adventurer>
{
    public AdventurerController(AdventurerService svc) : base(svc)
    { }
}