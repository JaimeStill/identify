using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerAccessoryService : SimpleEntityService<AdventurerAccessory>
{
    public AdventurerAccessoryService(AppDbContext db) : base(db) { }
}