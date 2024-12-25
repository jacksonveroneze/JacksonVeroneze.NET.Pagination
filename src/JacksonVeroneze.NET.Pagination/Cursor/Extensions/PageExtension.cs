namespace JacksonVeroneze.NET.Pagination.Cursor.Extensions;

public static class PageExtension
{
    public static Page<TType> ToPage<TType>(
        this ICollection<TType> source,
        bool hasMore,
        string? cursor)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(source);

        PageInfo pageInfo = new(hasMore, cursor);

        return new Page<TType>(source, pageInfo);
    }
}