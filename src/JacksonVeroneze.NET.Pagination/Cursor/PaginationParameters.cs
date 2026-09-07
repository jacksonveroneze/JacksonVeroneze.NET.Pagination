using JacksonVeroneze.NET.Pagination.Enums;

namespace JacksonVeroneze.NET.Pagination.Cursor;

public record PaginationParameters
{
    public PaginationParameters(
        int limit,
        string? cursor,
        PaginationDirection? paginationDirection)
    {
        Guard.Against.NegativeOrZero(limit);

        Limit = limit;
        Cursor = cursor;
        PaginationDirection = paginationDirection;
    }

    public PaginationParameters(
        int limit,
        string? cursor,
        PaginationDirection? paginationDirection,
        string? orderBy,
        SortDirection? sortDirection) :
        this(limit, cursor, paginationDirection)
    {
        OrderBy = orderBy;
        SortDirection = sortDirection;
    }

    public int? Limit { get; }

    public string? Cursor { get; }

    public PaginationDirection? PaginationDirection { get; }

    public string? OrderBy { get; }

    public SortDirection? SortDirection { get; }

    public bool PaginationNext => PaginationDirection
        is Enums.PaginationDirection.Next;

    public bool PaginationPrev => PaginationDirection
        is Enums.PaginationDirection.Previous;
}