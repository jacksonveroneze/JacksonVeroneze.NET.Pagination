namespace JacksonVeroneze.NET.Pagination
{
    public class PageInfo
    {
        public int Page { get; }

        public int PageSize { get; }

        public int TotalElements { get; }

        public string? OrderBy { get; }

        public SortDirection? Direction { get; }

        public int TotalPages =>
            TotalElements > 0 ? (int)Math.Ceiling(TotalElements / (decimal)(PageSize)) : 0;

        public bool IsFirstPage => Page == 1;

        public bool IsLastPage => Page == TotalPages;

        public PageInfo(int page, int pageSize, int totalElements)
        {
            Page = page;
            PageSize = pageSize;
            TotalElements = totalElements;
        }

        public PageInfo(int page, int pageSize,
            int totalElements, string orderBy,
            SortDirection direction)
            : this(page, pageSize, totalElements)
        {
            OrderBy = orderBy;
            Direction = direction;
        }
    }
}