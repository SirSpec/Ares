using System.Linq.Expressions;

namespace Ares.Domain.Specifications;

public class ExpressionSpecification<T> : Specification<T>
{
    private readonly Expression<Func<T, bool>> _expression;

    public ExpressionSpecification(Expression<Func<T, bool>> expression) =>
        _expression = expression;

    public override Expression<Func<T, bool>> ToExpression() =>
        _expression;
}