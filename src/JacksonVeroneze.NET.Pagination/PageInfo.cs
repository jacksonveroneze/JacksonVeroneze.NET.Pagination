namespace JacksonVeroneze.NET.Pagination
{
    public class PageInfo : PaginationParameters
    {
        public int TotalPages { get; }

        public int TotalElements { get; }

        public PageInfo(PaginationParameters parameters,
            int totalPages,
            int totalElements) : base(
            parameters.Page, parameters.PageSize,
            parameters.Direction, parameters.OrderBy)
        {
            TotalPages = totalPages;
            TotalElements = totalElements;
        }
    }
}