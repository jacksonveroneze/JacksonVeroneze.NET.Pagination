using JacksonVeroneze.NET.Pagination.Extensions;
using JacksonVeroneze.NET.Pagination.Util;
using JacksonVeroneze.NET.Pagination.Util.Builders;

namespace JacksonVeroneze.NET.Pagination.UnitTests;

[ExcludeFromCodeCoverage]
public class PageExtensionTests
{
    #region From_PaginationParameters

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : ToPage from PaginationParameters success")]
    public void ToPage_From_PaginationParameters_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 20;
        ICollection<User> data = UserBuilder.BuildMany(size);
        PaginationParameters pagination = new(1, size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data.ToPage(pagination);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.Pagination.Should()
            .NotBeNull();

        result.Pagination.Page.Should()
            .Be(1);

        result.Pagination.PageSize.Should()
            .Be(size);

        result.Pagination.TotalElements.Should()
            .Be(size);
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : ToPage from PaginationParameters"
                        + " (Invalid Data: Source) - ThrowException")]
    public void ToPage_From_PaginationParameters_InvalidData_Source_ThrowException()
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
                        + " : ToPage from PaginationParameters"
                        + " (Invalid Data: Pagination) - ThrowException")]
    public void ToPage_From_PaginationParameters_InvalidData_Pagination_ThrowException()
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

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : ToPage from parameters success")]
    public void ToPage_From_Parameters_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 20;
        const int page = 1;
        const int pageSize = 20;

        ICollection<User> data = UserBuilder.BuildMany(size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data.ToPage(page, pageSize);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.Pagination.Should()
            .NotBeNull();

        result.Pagination.Page.Should()
            .Be(page);

        result.Pagination.PageSize.Should()
            .Be(pageSize);

        result.Pagination.TotalElements.Should()
            .Be(size);
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : ToPage from parameters "
                        + " inform total elements success")]
    public void ToPage_From_Parameters_Inform_TotalElements_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 20;
        const int page = 1;
        const int pageSize = 20;
        const int totalElements = 120;

        ICollection<User> data = UserBuilder.BuildMany(size);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data.ToPage(page, pageSize, totalElements);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.Pagination.Should()
            .NotBeNull();

        result.Pagination.Page.Should()
            .Be(page);

        result.Pagination.PageSize.Should()
            .Be(pageSize);

        result.Pagination.TotalElements.Should()
            .Be(totalElements);
    }

    [Fact(DisplayName = nameof(PageExtension)
                        + nameof(PageExtension.ToPage)
                        + " : ToPage from parameters"
                        + " (Invalid Data) - ThrowException")]
    public void ToPage_From_Parameters_InvalidData_ThrowException()
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