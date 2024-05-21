namespace JacksonVeroneze.NET.Pagination;

public record PageInfo
{
    public PageInfo(int page, int pageSize, int totalElements)
    {
        Guard.Against.NegativeOrZero(page, nameof(page));
        Guard.Against.NegativeOrZero(pageSize, nameof(pageSize));
        Guard.Against.Negative(totalElements, nameof(totalElements));

        Page = page;
        PageSize = pageSize;
        TotalElements = totalElements;
    }

    public PageInfo(int page, int pageSize, int totalElements,
        string? orderBy, SortDirection? direction)
        : this(page, pageSize, totalElements)
    {
        OrderBy = orderBy;
        Direction = direction;
    }

    public int Page { get; }
    public int PageSize { get; }
    public int TotalElements { get; }

    public string? OrderBy { get; }

    public SortDirection? Direction { get; }

    public int TotalPages =>
        TotalElements > 0 ? (int)Math.Ceiling(TotalElements / (decimal)PageSize) : 0;

    public bool IsFirstPage => Page == 1;

    public bool IsLastPage => Page == TotalPages;

    public bool HasNextPage => Page < TotalPages;

    public bool HasBackPage => Page > 1;

    public int? NextPage =>
        Page == TotalPages ? null : Page + 1;

    public int? BackPage =>
        Page == 1 ? null : Page - 1;
}