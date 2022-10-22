using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerEyebrowService : SimpleEntityService<AdventurerEyebrow>
{
    public AdventurerEyebrowService(AppDbContext db) : base(db) { }
}