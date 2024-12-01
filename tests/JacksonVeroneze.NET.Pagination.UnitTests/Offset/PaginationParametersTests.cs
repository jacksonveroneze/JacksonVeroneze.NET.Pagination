using JacksonVeroneze.NET.Pagination.Common;
using JacksonVeroneze.NET.Pagination.Offset;

namespace JacksonVeroneze.NET.Pagination.UnitTests.Offset;

[ExcludeFromCodeCoverage]
public class PaginationParametersTests
{
    [Fact(DisplayName = nameof(PaginationParametersTests)
                        + " Initialize success")]
    public void Initialize_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int page = 5;
        const int pageSize = 10;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        PaginationParameters parameters =
            new(page, pageSize, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        parameters.Page.Should()
            .Be(page);
    }

    [Fact(DisplayName = nameof(PaginationParametersTests)
                        + " Sanitize Page Parameter Success")]
    public void Sanitize_Page_Parameter_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int page = 0;
        const int pageSize = 10;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        PaginationParameters parameters =
            new(page, pageSize, "field", SortDirection.Ascending);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        parameters.Page.Should()
            .Be(1);
    }

    [Theory(DisplayName = nameof(PaginationParametersTests)
                          + " Invalid Data ThrowException")]
    [InlineData(-1, 1)]
    [InlineData(1, -1)]
    [InlineData(1, 0)]
    public void Initialize_InvalidData_ThrowException(
        int page, int pageSize)
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        Action action = () =>
        {
            PaginationParameters _ = new(
                page, pageSize, "field", SortDirection.Ascending);
        };

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentException>();
    }
}