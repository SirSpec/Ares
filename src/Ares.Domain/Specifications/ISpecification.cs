using System.Linq.Expressions;

namespace Ares.Domain.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T @object);
    Expression<Func<T, bool>> ToExpression();
}
