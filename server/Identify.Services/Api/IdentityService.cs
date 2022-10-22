using Identify.Data;
using Identify.Models.Entities;

namespace Identify.Services.Api;
public abstract class IdentityService<T> : EntityService<T> where T : Identity
{
    public IdentityService(AppDbContext db) : base(db) { }
}