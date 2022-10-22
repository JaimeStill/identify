using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public class AdventurerService : IdentityService<Adventurer>
{
    public AdventurerService(AppDbContext db) : base(db) { }

    protected override Func<IQueryable<Adventurer>, string, IQueryable<Adventurer>> Search =>
        (values, term) =>
            values.Where(x =>
                x.Name.ToLower().Contains(term.ToLower())
                || x.LastName.ToLower().Contains(term.ToLower())
                || x.FirstName.ToLower().Contains(term.ToLower())
            );
}