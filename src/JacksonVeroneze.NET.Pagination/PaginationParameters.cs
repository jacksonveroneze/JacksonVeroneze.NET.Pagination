namespace JacksonVeroneze.NET.Pagination
{
    public class PaginationParameters
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public SortDirection Direction { get; set; }

        public string OrderBy { get; set; }

        public PaginationParameters()
        {
        }

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