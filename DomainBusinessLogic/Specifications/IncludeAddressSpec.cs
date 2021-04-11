using Ardalis.Specification;
using Entities;

namespace DomainBusinessLogic.Specifications
{
    public sealed class IncludeAddressSpec : Specification<User>
    {
        public IncludeAddressSpec()
        {
            Query.Include(u => u.Address);
        }
    }
}