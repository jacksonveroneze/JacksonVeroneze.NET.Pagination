using JacksonVeroneze.NET.Pagination.Offset;
using JacksonVeroneze.NET.Pagination.Offset.Extensions;
using JacksonVeroneze.NET.Pagination.Util;
using JacksonVeroneze.NET.Pagination.Util.Builders;

namespace JacksonVeroneze.NET.Pagination.UnitTests.Offset;

[ExcludeFromCodeCoverage]
public class PageExtensionTests
{
    #region From_PaginationParameters

    [Theory(DisplayName = nameof(PageExtension)
                          + nameof(PageExtension.ToPage)
                          + " : From PaginationParameters - Success")]
    [InlineData(20, 1, null)]
    [InlineData(20, 1, 100)]
    public void From_PaginationParameters_Success(
        int size, int page, int? totalElements = null)
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        ICollection<User> data = UserBuilder.BuildMany(size);
        PaginationParameters pagination = new(page, size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data
            .ToPage(pagination, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.PageInfo.Should()
            .NotBeNull();

        result.PageInfo.Page.Should()
            .Be(1);

        result.PageInfo.PageSize.Should()
            .Be(size);

        result.PageInfo.TotalElements.Should()
            .Be(totalElements ?? size);
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : From PaginationParameters "
                        + " inform total elements - Success")]
    public void From_PaginationParameters_Inform_TotalElements_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 20;
        const int totalElements = 120;
        ICollection<User> data = UserBuilder.BuildMany(size);
        PaginationParameters pagination = new(1, size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data.ToPage(pagination, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.PageInfo.Should()
            .NotBeNull();

        result.PageInfo.Page.Should()
            .Be(1);

        result.PageInfo.PageSize.Should()
            .Be(size);

        result.PageInfo.TotalElements.Should()
            .Be(totalElements);
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : From PaginationParameters"
                        + " (Invalid Data: Source) - ThrowException")]
    public void From_PaginationParameters_InvalidData_Source_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 20;
        ICollection<User>? data = null;
        PaginationParameters pagination = new(1, size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Action action = () => data!.ToPage(pagination);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : From PaginationParameters"
                        + " (Invalid Data: Pagination) - ThrowException")]
    public void From_PaginationParameters_InvalidData_Pagination_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 20;
        ICollection<User> data = UserBuilder.BuildMany(size);
        PaginationParameters? pagination = null;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Action action = () => data.ToPage(pagination!);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    #endregion

    #region From_Parameters

    [Theory(DisplayName = nameof(PageExtension)
                          + nameof(PageExtension.ToPage)
                          + " : From parameters - Success")]
    [InlineData(20, 1, null)]
    [InlineData(20, 1, 100)]
    public void From_Parameters_Success(
        int size, int page, int? totalElements = null)
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        ICollection<User> data = UserBuilder.BuildMany(size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data
            .ToPage(page, size, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.PageInfo.Should()
            .NotBeNull();

        result.PageInfo.Page.Should()
            .Be(page);

        result.PageInfo.PageSize.Should()
            .Be(size);

        result.PageInfo.TotalElements.Should()
            .Be(totalElements ?? size);
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : From parameters"
                        + " (Invalid Data) - ThrowException")]
    public void From_Parameters_InvalidData_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int page = 1;
        const int pageSize = 20;

        ICollection<User>? data = null;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Action action = () => data!.ToPage(page, pageSize);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    #endregion
}