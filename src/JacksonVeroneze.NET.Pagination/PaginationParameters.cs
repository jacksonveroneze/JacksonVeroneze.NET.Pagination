using Ardalis.GuardClauses;

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
            Guard.Against.Negative(page, nameof(page));
            Guard.Against.NegativeOrZero(pageSize, nameof(pageSize));

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