namespace JacksonVeroneze.NET.Pagination
{
    public class PaginationParameters
    {
        public int Page { get; }

        public int PageSize { get; }

        public SortDirection Direction { get; }

        public string OrderBy { get; }

        public PaginationParameters(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public PaginationParameters(int page, int pageSize,
            SortDirection direction, string orderBy) : this(page, pageSize)
        {
            Direction = direction;
            OrderBy = orderBy;
        }
    }
}