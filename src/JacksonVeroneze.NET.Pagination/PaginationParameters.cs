namespace JacksonVeroneze.NET.Pagination
{
    public class PaginationParameters
    {
        public int Page { get; }

        public int PageSize { get; }

        public string? OrderBy { get; }

        public SortDirection? Direction { get; }

        public PaginationParameters(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public PaginationParameters(int page, int pageSize,
            string orderBy, SortDirection direction) : this(page, pageSize)
        {
            OrderBy = orderBy;
            Direction = direction;
        }
    }
}