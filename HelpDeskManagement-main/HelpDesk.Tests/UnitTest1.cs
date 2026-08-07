using Xunit;

namespace HelpDesk.Tests;

public class UnitTest1
{
    [Fact]
    public void Addition_Test()
    {
        // Arrange
        int a = 10;
        int b = 20;

        // Act
        int result = a + b;

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void String_Test()
    {
        string title = "HelpDesk";

        Assert.Equal("HelpDesk", title);
    }
}