namespace JacksonVeroneze.NET.Pagination;

public class PaginationParameters
{
    public PaginationParameters(int page, int pageSize)
    {
        Guard.Against.Negative(page);
        Guard.Against.NegativeOrZero(pageSize);

        Page = page > 0 ? page : 1;
        PageSize = pageSize;
    }

    public PaginationParameters(int page, int pageSize,
        string? orderBy, SortDirection? direction) :
        this(page, pageSize)
    {
        OrderBy = orderBy;
        Direction = direction;
    }

    public int Page { get; }

    public int PageSize { get; }

    public string? OrderBy { get; }

    public SortDirection? Direction { get; }
}