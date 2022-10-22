using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class AdventurerMouthController : SimpleEntityController<AdventurerMouth>
{
    public AdventurerMouthController(AdventurerMouthService svc) : base(svc)
    { }
}