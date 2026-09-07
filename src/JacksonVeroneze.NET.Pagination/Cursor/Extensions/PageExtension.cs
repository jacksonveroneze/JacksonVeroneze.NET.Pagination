namespace JacksonVeroneze.NET.Pagination.Cursor.Extensions;

public static class PageExtension
{
    public static Page<TType> ToPage<TType>(
        this IEnumerable<TType> source,
        bool hasNext,
        string? nextCursor,
        string? previousCursor)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(source);

        PageInfo pageInfo = new(hasNext, nextCursor, previousCursor);

        return new Page<TType>(source, pageInfo);
    }

    public static Page<T> ToPage<T>(
        this ICollection<T> source,
        PaginationParameters? pagination,
        Func<T, string?> getCursor) where T : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(pagination);
        ArgumentNullException.ThrowIfNull(getCursor);

        int pageLimit = pagination.Limit!.Value;

        bool hasMore = source.Count > pageLimit;

        if (hasMore)
        {
            source = source
                .Take(pageLimit)
                .ToArray();
        }

        T? firstItem = source.FirstOrDefault();
        T? lastItem = source.LastOrDefault();

        bool hasPrevious =
            !string.IsNullOrEmpty(pagination.Cursor)
            && (pagination.PaginationNext || hasMore)
            && firstItem is not null;

        bool hasNext =
            (pagination.PaginationPrev || hasMore)
            && lastItem is not null;

        string? previousCursor = hasPrevious ? getCursor(firstItem!) : null;
        string? nextCursor = hasNext ? getCursor(lastItem!) : null;

        return new Page<T>(source, new PageInfo(
            hasMore, nextCursor, previousCursor,
            pagination.PaginationDirection));
    }
}