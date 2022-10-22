using Identify.Data;
using Identify.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identify.Services.Api;
public class BotService : IdentityService<Bot>
{
    public BotService(AppDbContext db) : base(db) { }

    protected override void ClearGraph(Bot entity)
    {
        entity.Make = null;
    }

    protected override IQueryable<Bot> SetGraph(DbSet<Bot> data) =>
        data.Include(x => x.Make);

    protected override Func<IQueryable<Bot>, string, IQueryable<Bot>> Search =>
        (values, term) =>
            values.Where(x =>
                x.Name.ToLower().Contains(term.ToLower())
                || x.Make.Name.ToLower().Contains(term.ToLower())
                || x.Model.ToLower().Contains(term.ToLower())
            );
}