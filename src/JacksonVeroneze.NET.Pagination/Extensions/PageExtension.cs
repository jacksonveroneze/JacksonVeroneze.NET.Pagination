namespace JacksonVeroneze.NET.Pagination.Extensions;

public static class PageExtension
{
    public static Page<TType> ToPage<TType>(
        this ICollection<TType> source,
        PaginationParameters pagination)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(
            source, nameof(source));

        ArgumentNullException.ThrowIfNull(
            pagination, nameof(pagination));

        return FactoryPage(source, pagination);
    }

    public static Page<TType> ToPage<TType>(
        this ICollection<TType> source,
        int page, int pageSize, int? totalElements = null)
        where TType : class
    {
        ArgumentNullException.ThrowIfNull(
            source, nameof(source));

        return FactoryPage(source, page, pageSize, totalElements);
    }

    private static Page<TType> FactoryPage<TType>(
        ICollection<TType> source,
        int page,
        int pageSize,
        int? totalElements = null)
    {
        PageInfo pageInfo = new(page, pageSize,
            totalElements ?? source.Count);

        return new Page<TType>(source, pageInfo);
    }

    private static Page<TType> FactoryPage<TType>(
        ICollection<TType> source,
        PaginationParameters pagination,
        int? totalElements = null)
    {
        PageInfo pageInfo = new(pagination.Page,
            pagination.PageSize,
            totalElements ?? source.Count,
            pagination.OrderBy,
            pagination.Direction);

        return new Page<TType>(source, pageInfo);
    }
}