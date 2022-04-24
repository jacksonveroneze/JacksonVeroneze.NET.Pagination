namespace JacksonVeroneze.NET.Pagination
{
    public class PaginationParameters
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public SortDirection Direction { get; set; }

        public string OrderBy { get; set; }

        public static PaginationParameters Factory(int page, int pageSize)
        {
            return new PaginationParameters
            {
                Page = page, 
                PageSize = pageSize
            };
        }

        public static PaginationParameters Factory(int page, int pageSize,
            SortDirection direction, string orderBy)

        {
            return new PaginationParameters
            {
                Page = page, 
                PageSize = pageSize, 
                Direction = direction, 
                OrderBy = orderBy
            };
        }
    }
}