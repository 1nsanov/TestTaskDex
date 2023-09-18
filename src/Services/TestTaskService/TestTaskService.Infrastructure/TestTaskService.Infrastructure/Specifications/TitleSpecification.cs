using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestTaskService.Application.Interfaces.Specification;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Infrastructure.Specifications;

public class TitleSpecification : ISpecification<Advertisement>
{
    public Expression<Func<Advertisement, bool>> SatisfiedBy { get; }
    public List<Func<IQueryable<Advertisement>, IOrderedQueryable<Advertisement>>>? OrderBy => null;

    public TitleSpecification(string? title)
    {
        SatisfiedBy = a => title == null || EF.Functions.ILike(a.Title, $"%{title}%");
    }
}