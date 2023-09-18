using System.Linq.Expressions;

namespace TestTaskService.Application.Interfaces.Specification;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> SatisfiedBy { get; }
    List<Func<IQueryable<T>, IOrderedQueryable<T>>>? OrderBy { get; }
}