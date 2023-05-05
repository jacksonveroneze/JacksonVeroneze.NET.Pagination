namespace JacksonVeroneze.NET.Pagination;

public class Page<T>
{
    public Page(IEnumerable<T> data, PageInfo pagination)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));
        ArgumentNullException.ThrowIfNull(pagination, nameof(pagination));

        Data = data;
        Pagination = pagination;
    }

    public IEnumerable<T> Data { get; init; }

    public PageInfo Pagination { get; init; }
}