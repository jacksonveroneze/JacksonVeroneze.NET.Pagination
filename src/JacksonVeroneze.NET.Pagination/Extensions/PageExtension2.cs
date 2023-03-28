namespace JacksonVeroneze.NET.Pagination.Extensions;

public static class PageExtension2
{
    public static Page<TType> ToPage2<TType>(
        this ICollection<TType> source,
        PaginationParameters pagination)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(
            source, nameof(source));

        ArgumentNullException.ThrowIfNull(
            pagination, nameof(pagination));

        return GerPage(source, pagination);
    }

    private static Page<TType> GerPage<TType>(
        ICollection<TType> source,
        PaginationParameters pagination)
    {
        ICollection<TType> pageItems =
            GetPageItems(source, pagination);

        PageInfo pageInfo = new(pagination.Page,
            pagination.PageSize, source.Count);

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