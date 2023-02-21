namespace JacksonVeroneze.NET.Pagination
{
    public class Page<T>
    {
        public ICollection<T> Data { get; }

        public PageInfo Pagination { get; }

        public Page(ICollection<T> data, PageInfo pagination)
        {
            Data = data;
            Pagination = pagination;
        }
    }
}