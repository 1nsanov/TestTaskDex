using System.Linq.Expressions;
using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Application.Interfaces.Specification;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Infrastructure.Specifications;

public class SortSpecification : ISpecification<Advertisement>
{
    public Expression<Func<Advertisement, bool>> SatisfiedBy => a => true;
    public List<Func<IQueryable<Advertisement>, IOrderedQueryable<Advertisement>>>? OrderBy { get; }

    public SortSpecification(AdvertisementSortOrder sortOrder)
    {
        OrderBy = new List<Func<IQueryable<Advertisement>, IOrderedQueryable<Advertisement>>>
        {
            queryable => sortOrder switch
            {
                AdvertisementSortOrder.NumberAscending => queryable.OrderBy(a => a.Number),
                AdvertisementSortOrder.NumberDescending => queryable.OrderByDescending(a => a.Number),
                AdvertisementSortOrder.RateAscending => queryable.OrderBy(a => a.Rate),
                AdvertisementSortOrder.RateDescending => queryable.OrderByDescending(a => a.Rate),
                AdvertisementSortOrder.ExpirationDateAscending => queryable.OrderBy(a => a.ExpireDate),
                AdvertisementSortOrder.ExpirationDateDescending => queryable.OrderByDescending(a => a.ExpireDate),
                _ => queryable.OrderBy(a => a.Id)
            }
        };
    }
}