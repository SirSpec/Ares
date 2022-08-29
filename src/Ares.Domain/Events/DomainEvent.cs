namespace Ares.Domain.Events;

public abstract record DomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public DateTime Created { get; }
}
