namespace JacksonVeroneze.NET.Pagination
{
    public class PageInfo : PaginationParameters
    {
        public int TotalPages { get; set; }

        public int TotalElements { get; set;}

        public PageInfo()
        {
            
        }
        
        public PageInfo(PaginationParameters parameters,
            int totalPages,
            int totalElements) : base(
            parameters.Page, parameters.PageSize,
            parameters.Direction, parameters.OrderBy)
        {
            TotalPages = totalPages;
            TotalElements = totalElements;
        }

        public PageInfo(int page, int pageSize,
            int totalPages,
            int totalElements) : base(page, pageSize)
        {
            TotalPages = totalPages;
            TotalElements = totalElements;
        }
    }
}