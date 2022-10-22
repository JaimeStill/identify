using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class AdventurerEyebrowController : SimpleEntityController<AdventurerEyebrow>
{
    public AdventurerEyebrowController(AdventurerEyebrowService svc) : base(svc)
    { }
}