namespace JacksonVeroneze.NET.Pagination
{
    public class PageInfo : PaginationParameters
    {
        public int TotalPages { get; set; }

        public int TotalElements { get; set; }

        public static PageInfo FactoryPageInfo(PaginationParameters parameters,
            int totalPages,
            int totalElements)
        {
            return new PageInfo
            {
                Page = parameters.Page,
                PageSize = parameters.PageSize,
                TotalPages = totalPages,
                TotalElements = totalElements
            };
        }

        public static PageInfo FactoryPageInfo(int page, int pageSize,
            int totalPages,
            int totalElements)
        {
            return new PageInfo
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalElements = totalElements
            };
        }
    }
}