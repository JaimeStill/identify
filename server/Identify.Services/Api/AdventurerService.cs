using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerService : IdentityService<Adventurer>
{
    public AdventurerService(AppDbContext db) : base(db) { }
}