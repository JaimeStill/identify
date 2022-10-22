using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class BotService : IdentityService<Bot>
{
    public BotService(AppDbContext db) : base(db) { }
}