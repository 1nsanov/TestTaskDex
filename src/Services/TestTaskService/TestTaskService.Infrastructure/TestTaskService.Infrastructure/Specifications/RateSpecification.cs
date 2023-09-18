using System.Linq.Expressions;
using TestTaskService.Application.Interfaces.Specification;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Infrastructure.Specifications;

public class RateSpecification : ISpecification<Advertisement>
{
    public Expression<Func<Advertisement, bool>> SatisfiedBy { get; }
    public List<Func<IQueryable<Advertisement>, IOrderedQueryable<Advertisement>>>? OrderBy => null;

    public RateSpecification(int? minRate)
    {
        SatisfiedBy = a => minRate == null || a.Rate >= minRate;
    }
}