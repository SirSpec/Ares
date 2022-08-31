using System.Linq.Expressions;
using Ares.Domain.Entities;

namespace Ares.Domain.Repositories;

public interface IReadOnlyRepository<TAggregateRoot, TIdentity>
    where TAggregateRoot : AggregateRoot<TIdentity>
{
    Task<TAggregateRoot> GetAsync(TIdentity id, CancellationToken cancellationToken = default);

    Task<List<TAggregateRoot>> GetListAsync(
        Expression<Func<TAggregateRoot, bool>> predicate,
        CancellationToken cancellationToken = default);
}
