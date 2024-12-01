using System.Collections.ObjectModel;
using JacksonVeroneze.NET.Pagination.Common;

namespace JacksonVeroneze.NET.Pagination.Offset;

public record Page<TEntity> : PageBase<TEntity, PageInfo>
    where TEntity : class
{
    public Page(List<TEntity> data, PageInfo pageInfo)
        : base(data, pageInfo)
    {
    }

    public Page(ICollection<TEntity> data, PageInfo pageInfo)
        : base(data, pageInfo)
    {
    }

    public Page(IEnumerable<TEntity> data, PageInfo pageInfo)
        : base(data, pageInfo)
    {
    }

    public Page(ReadOnlyCollection<TEntity> data, PageInfo pageInfo)
        : base(data, pageInfo)
    {
    }
}