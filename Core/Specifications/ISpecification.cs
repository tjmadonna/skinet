using System.Linq.Expressions;

namespace Core.Specifications;

public interface ISpecification<T>
{
    // Where clauses
    Expression<Func<T, bool>> Criteria { get; }

    // Includes
    List<Expression<Func<T, object>>> Includes { get; }
}