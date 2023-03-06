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
            TotalElements > 0 ? (int)Math.Ceiling(TotalElements / (decimal)PageSize) : 0;

        public bool IsFirstPage => Page == 1;

        public bool IsLastPage => Page == TotalPages;

        public PageInfo(int page, int pageSize, int totalElements)
        {
            if (page <= 0)
            {
                throw new ArgumentException(
                    $"Argument '{nameof(page)}' must be greater than zero");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException(
                    $"Argument '{nameof(pageSize)}' must be greater than zero");
            }

            if (totalElements < 0)
            {
                throw new ArgumentException(
                    $"Argument '{nameof(totalElements)}' must be greater than or equal to zero");
            }

            Page = page;
            PageSize = pageSize;
            TotalElements = totalElements;
        }

        public PageInfo(int page, int pageSize,
            int totalElements, string? orderBy,
            SortDirection? direction)
            : this(page, pageSize, totalElements)
        {
            OrderBy = orderBy;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{nameof(PageInfo)}: " +
                   $"Page: {Page} - PageSize: {PageSize} - " +
                   $"TotalElements: {TotalElements} - OrderBy: {OrderBy} - " +
                   $"Direction: {Direction} - TotalPages: {TotalPages} - " +
                   $"IsFirstPage: {IsFirstPage} - IsLastPage: {IsLastPage}";
        }
    }
}