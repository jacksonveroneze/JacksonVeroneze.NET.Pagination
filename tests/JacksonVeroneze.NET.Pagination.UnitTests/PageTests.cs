using JacksonVeroneze.NET.Pagination.Util;
using JacksonVeroneze.NET.Pagination.Util.Builders;

namespace JacksonVeroneze.NET.Pagination.UnitTests;

[ExcludeFromCodeCoverage]
public class PageTests
{
    [Fact(DisplayName = nameof(Page<User>)
                        + " Initialize success")]
    public void Initialize_Success()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        List<User> data = UserBuilder.BuildMany(10);
        PageInfo pageInfo = new(1, 1, 10);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Page<User> page = new(data, pageInfo);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        page.Should()
            .NotBeNull();

        page.Data.Should()
            .NotBeNull();

        page.Pagination.Should()
            .NotBeNull();
    }

    [Fact(DisplayName = nameof(Page<User>)
                        + " Invalid Data ThrowException")]
    public void Initialize_InvalidData_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        List<User>? data = null;
        PageInfo pageInfo = new(1, 1, 10);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Action action = () => new Page<User>(data!, pageInfo);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact(DisplayName = nameof(Page<User>)
                        + " Invalid PageInfo ThrowException")]
    public void Initialize_InvalidPageInfo_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        List<User> data = UserBuilder.BuildMany(10);
        PageInfo? pageInfo = null;

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        Action action = () => new Page<User>(data, pageInfo!);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }
}