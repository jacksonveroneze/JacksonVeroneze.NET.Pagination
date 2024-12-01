using JacksonVeroneze.NET.Pagination.Common;

namespace JacksonVeroneze.NET.Pagination.Cursor;

public record PaginationParameters
{
    public PaginationParameters(int limit, string? cursor)
    {
        Guard.Against.NegativeOrZero(limit);

        Limit = limit;
        Cursor = cursor;
    }

    public PaginationParameters(int limit, string? cursor,
        string? orderBy, SortDirection? direction) :
        this(limit, cursor)
    {
        OrderBy = orderBy;
        Direction = direction;
    }

    public int? Limit { get; }

    public string? Cursor { get; }

    public string? OrderBy { get; }

    public SortDirection? Direction { get; }
}