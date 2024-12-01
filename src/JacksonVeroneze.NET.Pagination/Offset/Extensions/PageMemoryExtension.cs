namespace JacksonVeroneze.NET.Pagination.Offset.Extensions;

public static class PageMemoryExtension
{
    public static Page<TType> ToPageInMemory<TType>(
        this ICollection<TType> source,
        PaginationParameters pagination,
        int? totalElements = null)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(pagination);

        return GetPage(source, pagination, totalElements);
    }

    private static Page<TType> GetPage<TType>(
        ICollection<TType> source,
        PaginationParameters pagination,
        int? totalElements = null)
        where TType : class
    {
        int count = totalElements ?? source.Count;

        IEnumerable<TType> pageItems =
            GetPageItems(source, pagination);

        PageInfo pageInfo = new(pagination.Page,
            pagination.PageSize, count);

        return new Page<TType>(pageItems, pageInfo);
    }

    private static IEnumerable<TType> GetPageItems<TType>(
        IEnumerable<TType> source,
        PaginationParameters pagination)
    {
        return source
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize);
    }
}