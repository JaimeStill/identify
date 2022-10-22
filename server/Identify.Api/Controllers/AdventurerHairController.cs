using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class AdventurerHairController : SimpleEntityController<AdventurerHair>
{
    public AdventurerHairController(AdventurerHairService svc) : base(svc)
    { }
}