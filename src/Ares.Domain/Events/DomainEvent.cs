namespace Ares.Domain.Events;

public record DomainEvent
{
    public DomainEvent(object data)
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
        Order = 0; //ToDo: Increment
        Data = data;
    }

    public Guid Id { get; }
    public DateTime Created { get; }
    public long Order { get; }
    public object Data { get; }
}
