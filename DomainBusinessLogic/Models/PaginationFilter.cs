namespace DomainBusinessLogic.Models
{
    public class PaginationFilter
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 100;
    }
}