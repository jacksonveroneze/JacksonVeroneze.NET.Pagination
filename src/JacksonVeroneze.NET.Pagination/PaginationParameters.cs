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
            if (page < 0)
            {
                throw new ArgumentException(
                    $"Argument '{nameof(page)}' must be greater than or equal to zero");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException(
                    $"Argument '{nameof(pageSize)}' must be greater than zero");
            }

            Page = page > 0 ? page : 1;
            PageSize = pageSize;
        }

        public PaginationParameters(int page, int pageSize,
            string orderBy, SortDirection direction) : this(page, pageSize)
        {
            OrderBy = orderBy;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{nameof(PaginationParameters)}: " +
                   $"Page: {Page} - PageSize: {PageSize} - " +
                   $"OrderBy: {OrderBy} - Direction: {Direction}";
        }
    }
}