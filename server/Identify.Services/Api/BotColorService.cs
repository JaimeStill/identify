using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class BotColorService : SimpleEntityService<BotColor>
{
    public BotColorService(AppDbContext db) : base(db) { }
}