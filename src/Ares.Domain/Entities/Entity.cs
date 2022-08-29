namespace Ares.Domain.Entities;

public abstract class Entity<TIdentity>
{
    public TIdentity Id { get; }

    protected Entity(TIdentity id) =>
        Id = id;
}
