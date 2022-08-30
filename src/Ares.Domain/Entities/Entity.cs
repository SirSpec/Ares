using Ares.Domain.Events;

namespace Ares.Domain.Entities;

public abstract class Entity<TIdentity>
{
    private readonly List<DomainEvent> _events;

    public TIdentity Id { get; }
    public IReadOnlyList<DomainEvent> Events => _events;

    protected Entity(TIdentity id)
    {
        Id = id;
        _events = new List<DomainEvent>();
    }

    public void ClearEvents() =>
        _events.Clear();

    protected void AddEvent(object data) =>
        _events.Add(new DomainEvent(data));
}
