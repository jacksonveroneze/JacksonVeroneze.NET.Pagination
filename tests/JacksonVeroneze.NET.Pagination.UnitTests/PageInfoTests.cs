namespace JacksonVeroneze.NET.Pagination.UnitTests;

[ExcludeFromCodeCoverage]
public class PageInfoTests
{
    [Fact(DisplayName = nameof(PageInfo)
                        + " TotalPages success")]
    public void TotalPages_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int page = 1;
        const int pageSize = 10;
        const int totalElements = 100;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        PageInfo pageInfo = new(page, pageSize, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.TotalPages.Should()
            .Be(10);
    }

    [Fact(DisplayName = nameof(PageInfo)
                        + " IsFirstPage success")]
    public void IsFirstPage_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int page = 1;
        const int pageSize = 10;
        const int totalElements = 100;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        PageInfo pageInfo = new(page, pageSize, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.IsFirstPage.Should()
            .BeTrue();

        pageInfo.IsLastPage.Should()
            .BeFalse();
    }

    [Fact(DisplayName = nameof(PageInfo)
                        + " IsLastPage success")]
    public void IsLastPage_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int page = 10;
        const int pageSize = 10;
        const int totalElements = 100;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        PageInfo pageInfo = new(page, pageSize, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        pageInfo.IsFirstPage.Should()
            .BeFalse();

        pageInfo.IsLastPage.Should()
            .BeTrue();
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
        Action action = () =>
            new PageInfo(page, pageSize, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentException>();
    }
}