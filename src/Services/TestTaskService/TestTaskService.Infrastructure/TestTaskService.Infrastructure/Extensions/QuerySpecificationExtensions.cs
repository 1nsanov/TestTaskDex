using TestTaskService.Application.Interfaces.Specification;

namespace TestTaskService.Infrastructure.Extensions;

public static class QuerySpecificationExtensions
{
    public static IQueryable<T> ApplySpecify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        query = query.Where(spec.SatisfiedBy);
        
        if (spec.OrderBy != null)
        {
            query = spec.OrderBy
                .Aggregate(query, (current, orderBy) => orderBy(current));
        }

        return query;
    }
}