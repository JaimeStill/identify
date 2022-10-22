using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class AdventurerEyeController : SimpleEntityController<AdventurerEye>
{
    public AdventurerEyeController(AdventurerEyeService svc) : base(svc)
    { }
}