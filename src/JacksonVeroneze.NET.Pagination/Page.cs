using System.Collections.Generic;

namespace JacksonVeroneze.NET.Pagination
{
    public class Page<T>
    {
        public ICollection<T> Data { get; set;}

        public PageInfo Pagination { get; set;}

        public Page(ICollection<T> data, PageInfo pagination)
        {
            Data = data;
            Pagination = pagination;
        }
    }
}