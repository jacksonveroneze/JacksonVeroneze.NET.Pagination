namespace JacksonVeroneze.NET.Pagination.Extensions;

public static class PageMemoryExtension
{
    public static Page<TType> ToPageFromMemory<TType>(
        this ICollection<TType> source,
        PaginationParameters pagination,
        int? totalElements = null)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(pagination, nameof(pagination));

        return GerPage(source, pagination, totalElements);
    }

    private static Page<TType> GerPage<TType>(
        ICollection<TType> source,
        PaginationParameters pagination,
        int? totalElements = null)
    {
        int count = totalElements ?? source.Count;

        ICollection<TType> pageItems =
            GetPageItems(source, pagination);

        PageInfo pageInfo = new(pagination.Page,
            pagination.PageSize, count);

        return new Page<TType>(pageItems, pageInfo);
    }

    private static ICollection<TType> GetPageItems<TType>(
        IEnumerable<TType> source,
        PaginationParameters pagination)
    {
        return source
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToArray();
    }
}