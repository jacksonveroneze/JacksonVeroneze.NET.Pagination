using System.Collections.ObjectModel;

namespace JacksonVeroneze.NET.Pagination;

public record Page<T>
{
    public Page(List<T> data, PageInfo pagination) :
        this(data.AsReadOnly(), pagination)
    {
    }

    public Page(ICollection<T> data, PageInfo pagination) :
        this(((List<T>)data).AsReadOnly(), pagination)
    {
    }

    public Page(IEnumerable<T> data, PageInfo pagination) :
        this((data.ToList()).AsReadOnly(), pagination)
    {
    }

    public Page(ReadOnlyCollection<T> data, PageInfo pagination)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(pagination);

        Data = data;
        Pagination = pagination;
    }

    public ReadOnlyCollection<T> Data { get; }

    public PageInfo Pagination { get; }
}