namespace JacksonVeroneze.NET.Pagination
{
    public class Page<T>
    {
        public ICollection<T> Data { get; }

        public PageInfo Pagination { get; }

        public Page(ICollection<T> data, PageInfo pagination)
        {
            ArgumentNullException.ThrowIfNull(data, nameof(data));
            ArgumentNullException.ThrowIfNull(pagination, nameof(pagination));

            Data = data;
            Pagination = pagination;
        }
    }
}