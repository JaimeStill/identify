using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerHairService : SimpleEntityService<AdventurerHair>
{
    public AdventurerHairService(AppDbContext db) : base(db) { }
}