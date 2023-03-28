using JacksonVeroneze.NET.Pagination.Extensions;
using JacksonVeroneze.NET.Pagination.Util;
using JacksonVeroneze.NET.Pagination.Util.Builders;

namespace JacksonVeroneze.NET.Pagination.UnitTests;

[ExcludeFromCodeCoverage]
public class PageExtensionTests2
{
    #region From_PaginationParameters

    [Fact(DisplayName = nameof(PageExtension2)
                        + nameof(PageExtension2.ToPage2)
                        + " : ToPage2 from PaginationParameters success")]
    public void ToPage2_From_PaginationParameters_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        const int size = 150;
        const int page = 2;
        const int pageSize = 20;

        ICollection<User> data = UserBuilder.BuildMany(size);
        PaginationParameters pagination = new(page, pageSize);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data.ToPage2(pagination);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        ICollection<User> elementsCheck = data
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToArray();

        result.Should()
            .NotBeNull();

        result.Data.Should()
            .NotBeNull();

        result.Data.Should()
            .BeEquivalentTo(elementsCheck);

        result.Pagination.Should()
            .NotBeNull();

        result.Pagination.Page.Should()
            .Be(page);

        result.Pagination.PageSize.Should()
            .Be(pageSize);

        result.Pagination.TotalElements.Should()
            .Be(size);
    }

    [Fact(DisplayName = nameof(PageExtension2)
                        + nameof(PageExtension2.ToPage2)
                        + " : ToPage2 from PaginationParameters"
                        + " (Invalid Data: Source) - ThrowException")]
    public void ToPage2_From_PaginationParameters_InvalidData_Source_ThrowException()
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
        Action action = () => data!.ToPage2(pagination);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact(DisplayName = nameof(PageExtension2)
                        + nameof(PageExtension2.ToPage2)
                        + " : ToToPage2Page from PaginationParameters"
                        + " (Invalid Data: Pagination) - ThrowException")]
    public void ToPage2_From_PaginationParameters_InvalidData_Pagination_ThrowException()
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
        Action action = () => data.ToPage2(pagination!);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    #endregion
}