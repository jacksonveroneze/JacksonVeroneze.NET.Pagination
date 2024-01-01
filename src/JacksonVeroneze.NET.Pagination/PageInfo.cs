namespace JacksonVeroneze.NET.Pagination;

public class PageInfo
{
    public PageInfo()
    {
    }

    public PageInfo(int page, int pageSize, int totalElements)
    {
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

    private readonly int _page;
    private readonly int _pageSize;
    private readonly int _totalElements;

    public int Page
    {
        get => _page;
        init
        {
            Guard.Against.NegativeOrZero(
                value, nameof(Page));

            _page = value;
        }
    }

    public int PageSize
    {
        get => _pageSize;
        init
        {
            Guard.Against.NegativeOrZero(
                value, nameof(PageSize));

            _pageSize = value;
        }
    }

    public int TotalElements
    {
        get => _totalElements;
        init
        {
            Guard.Against.Negative(
                value, nameof(TotalElements));

            _totalElements = value;
        }
    }

    public string? OrderBy { get; init; }

    public SortDirection? Direction { get; init; }

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