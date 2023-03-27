namespace JacksonVeroneze.NET.Pagination.Extensions;

public static class PageExtension2
{
    public static Page<TType> ToPage<TType>(
        this ICollection<TType> source,
        PaginationParameters pagination,
        int? totalElements = null)
        where TType : class
    {
        ArgumentException.ThrowIfNullOrEmpty(
            nameof(source), nameof(source));

        ArgumentException.ThrowIfNullOrEmpty(
            nameof(pagination), nameof(pagination));

        return GerPageFromOrdered(
            source, pagination, totalElements);
    }

    private static Page<TType> GerPageFromOrdered<TType>(
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
        Guard.Against.NegativeOrZero(
            pagination.Page, nameof(pagination.Page));

        Guard.Against.NegativeOrZero(
            pagination.PageSize, nameof(pagination.PageSize));

        return source
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToArray();
    }
}