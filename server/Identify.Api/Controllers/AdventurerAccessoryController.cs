using Identify.Models.Entities;
using Identify.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Identify.Api.Controllers;

[Route("api/[controller]")]
public class AdventurerAccessoryController : SimpleEntityController<AdventurerAccessory>
{
    public AdventurerAccessoryController(AdventurerAccessoryService svc) : base(svc)
    { }
}