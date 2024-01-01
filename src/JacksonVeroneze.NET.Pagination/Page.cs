namespace JacksonVeroneze.NET.Pagination;

public class Page<T>
{
    public Page(IEnumerable<T> data, PageInfo pagination)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(pagination);

        Data = data;
        Pagination = pagination;
    }

    public IEnumerable<T> Data { get; }

    public PageInfo Pagination { get; }
}