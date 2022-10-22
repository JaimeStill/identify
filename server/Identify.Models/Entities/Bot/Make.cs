namespace Identify.Models.Entities;
public class Make : Entity
{
    public ICollection<Bot> Bots { get; set; }
}