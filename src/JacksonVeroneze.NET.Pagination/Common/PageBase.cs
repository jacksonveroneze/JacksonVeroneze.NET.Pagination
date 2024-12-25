using System.Collections.ObjectModel;

namespace JacksonVeroneze.NET.Pagination.Common;

public abstract record PageBase<TEntity, TPageInfo>
    where TEntity : class
    where TPageInfo : class
{
    protected PageBase(TEntity[]? data, TPageInfo pageInfo) :
        this(data?.AsReadOnly(), pageInfo)
    {
    }

    protected PageBase(List<TEntity>? data, TPageInfo pageInfo) :
        this(data?.AsReadOnly(), pageInfo)
    {
    }

    protected PageBase(ICollection<TEntity>? data, TPageInfo pageInfo) :
        this(data?.ToList() ?? [], pageInfo)
    {
    }

    protected PageBase(IEnumerable<TEntity>? data, TPageInfo pageInfo) :
        this(data?.ToList() ?? [], pageInfo)
    {
    }

    protected PageBase(ReadOnlyCollection<TEntity>? data, TPageInfo pageInfo)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(pageInfo);

        Data = data;
        PageInfo = pageInfo;
    }

    public ReadOnlyCollection<TEntity> Data { get; }

    public TPageInfo PageInfo { get; }
}