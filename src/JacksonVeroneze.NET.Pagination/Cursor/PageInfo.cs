namespace JacksonVeroneze.NET.Pagination.Cursor;

public record PageInfo
{
    public PageInfo(bool hasMore, string? cursor)
    {
        if (hasMore && string.IsNullOrWhiteSpace(cursor))
        {
            throw new ArgumentNullException(nameof(cursor));
        }

        HasMore = hasMore;
        Cursor = cursor;
    }

    public bool HasMore { get; }
    public string? Cursor { get; }
}