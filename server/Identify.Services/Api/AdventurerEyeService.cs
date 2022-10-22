using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerEyeService : SimpleEntityService<AdventurerEye>
{
    public AdventurerEyeService(AppDbContext db) : base(db) { }
}