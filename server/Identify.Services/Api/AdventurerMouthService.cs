using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerMouthService : SimpleEntityService<AdventurerMouth>
{
    public AdventurerMouthService(AppDbContext db) : base(db) { }
}