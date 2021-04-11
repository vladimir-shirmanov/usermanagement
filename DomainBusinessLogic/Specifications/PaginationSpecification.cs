using Ardalis.Specification;
using DomainBusinessLogic.Models;
using Entities;

namespace DomainBusinessLogic.Specifications
{
    public class PaginationSpecification<T, TResult> : Specification<T, TResult> where T: BaseEntity
    {
        protected PaginationSpecification(PaginationFilter filter)
        {
            Query.OrderBy(e => e.Id).Skip(filter.Page * filter.PageSize).Take(filter.PageSize);
        }
    }
}