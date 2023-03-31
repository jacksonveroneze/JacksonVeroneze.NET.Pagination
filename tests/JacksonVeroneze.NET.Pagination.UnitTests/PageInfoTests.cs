namespace JacksonVeroneze.NET.Pagination.UnitTests;

[ExcludeFromCodeCoverage]
public class PageInfoTests
{
    [Theory(DisplayName = nameof(PageInfo)
                          + " TotalPages success")]
    [InlineData(1, 1, 0, 0)]
    [InlineData(1, 1, 1, 1)]
    [InlineData(1, 50, 100, 2)]
    [InlineData(1, 10, 100, 10)]
    [InlineData(1, 10, 1000, 100)]
    public void TotalPages_Success(
        int page, int pageSize, int totalElements,
        int expected)
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        PageInfo pageInfo = new(page, pageSize,
            totalElements, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.TotalPages.Should()
            .Be(expected);
    }

    [Theory(DisplayName = nameof(PageInfo)
                          + " FirstLastPage success")]
    [InlineData(1, 10, 10, true, true)]
    [InlineData(1, 10, 100, true, false)]
    [InlineData(10, 10, 100, false, true)]
    public void FirstLastPage_Success(
        int page, int pageSize, int totalElements,
        bool expectedFirst, bool expectedLast)
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        PageInfo pageInfo = new(page, pageSize,
            totalElements, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.IsFirstPage.Should()
            .Be(expectedFirst);

        pageInfo.IsLastPage.Should()
            .Be(expectedLast);
    }

    [Theory(DisplayName = nameof(PageInfo)
                          + " HasNextBackPage success")]
    [InlineData(1, 10, 10, false, false)]
    [InlineData(1, 10, 100, true, false)]
    [InlineData(10, 10, 100, false, true)]
    public void HasNextBackPage_Success(
        int page, int pageSize, int totalElements,
        bool expectedHasNext, bool expectedHasBack)
    {
        PageInfo pageInfo = new(page, pageSize,
            totalElements, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.HasNextPage.Should()
            .Be(expectedHasNext);

        pageInfo.HasBackPage.Should()
            .Be(expectedHasBack);
    }

    [Theory(DisplayName = nameof(PageInfo)
                          + " NextBackPage success")]
    [InlineData(1, 10, 10, null, null)]
    [InlineData(1, 10, 100, 2, null)]
    [InlineData(10, 10, 100, null, 9)]
    [InlineData(25, 10, 250, null, 24)]
    [InlineData(20, 10, 250, 21, 19)]
    public void NextBackPage_Success(
        int page, int pageSize, int totalElements,
        int? nextPage, int? backPage)
    {
        PageInfo pageInfo = new(page, pageSize,
            totalElements, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.NextPage.Should()
            .Be(nextPage);

        pageInfo.BackPage.Should()
            .Be(backPage);
    }

    [Theory(DisplayName = nameof(PageInfo)
                          + " Invalid Data ThrowException")]
    [InlineData(-1, 1, 1)]
    [InlineData(0, 1, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, -1)]
    public void Initialize_InvalidData_ThrowException(
        int page, int pageSize, int totalElements)
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        Action action = () => new PageInfo(page, pageSize,
            totalElements, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentException>();
    }
}