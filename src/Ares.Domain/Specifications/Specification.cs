using System.Linq.Expressions;

namespace Ares.Domain.Specifications;

public abstract class Specification<T> : ISpecification<T>
{
    public bool IsSatisfiedBy(T @object) =>
        ToExpression().Compile()(@object);

    public abstract Expression<Func<T, bool>> ToExpression();

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification) =>
        specification.ToExpression();
}
