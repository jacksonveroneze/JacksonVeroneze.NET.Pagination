using JacksonVeroneze.NET.Pagination.Enums;

namespace JacksonVeroneze.NET.Pagination.Cursor;

public record PageInfo
{
    public PageInfo(
        bool hasMore,
        string? nextCursor = null,
        string? previousCursor = null,
        PaginationDirection? paginationDirection = null)
    {
        HasMore = hasMore;
        NextCursor = nextCursor;
        PreviousCursor = previousCursor;
        PaginationDirection = paginationDirection;
    }

    public bool? HasMore { get; }

    public string? NextCursor { get; }

    public string? PreviousCursor { get; }

    public PaginationDirection? PaginationDirection { get; }
}