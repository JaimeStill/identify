using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class MakeService : SimpleEntityService<Make>
{
    public MakeService(AppDbContext db) : base(db) { }
}