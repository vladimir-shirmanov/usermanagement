using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class EfRepository<T> : RepositoryBase<T> where T : BaseEntity
    {
        public EfRepository([NotNull] DbContext dbContext) : base(dbContext)
        {
        }

        public EfRepository([NotNull] DbContext dbContext, [NotNull] ISpecificationEvaluator specificationEvaluator)
            : base(dbContext, specificationEvaluator)
        {
        }
    }
}