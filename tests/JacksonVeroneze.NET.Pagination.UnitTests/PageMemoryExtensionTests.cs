using JacksonVeroneze.NET.Pagination.Extensions;
using JacksonVeroneze.NET.Pagination.Util;
using JacksonVeroneze.NET.Pagination.Util.Builders;

namespace JacksonVeroneze.NET.Pagination.UnitTests;

[ExcludeFromCodeCoverage]
public class PageMemoryExtensionTests
{
    #region From_PaginationParameters

    [Theory(DisplayName = nameof(PageMemoryExtension)
                          + nameof(PageMemoryExtension.ToPageFromMemory)
                          + " : From PaginationParameters - Success")]
    [InlineData(20, 2, 5, 200)]
    [InlineData(50, 2, 10, 100)]
    [InlineData(150, 5, 20, null)]
    [InlineData(180, 10, 2, null)]
    public void From_PaginationParameters_Success(
        int size, int page, int pageSize,
        int? totalElements = null)
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        ICollection<User> data = UserBuilder.BuildMany(size);
        PaginationParameters pagination = new(page, pageSize);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> result = data
            .ToPageFromMemory(pagination, totalElements);

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
            .Be(totalElements ?? size);
    }

    [Fact(DisplayName = nameof(PageMemoryExtension)
                        + nameof(PageMemoryExtension.ToPageFromMemory)
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
        Action action = () => data!.ToPageFromMemory(pagination);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact(DisplayName = nameof(PageMemoryExtension)
                        + nameof(PageMemoryExtension.ToPageFromMemory)
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
        Action action = () => data.ToPageFromMemory(pagination!);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    #endregion
}