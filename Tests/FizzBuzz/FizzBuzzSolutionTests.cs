using Examples.FizzBuzz;

namespace Tests.FizzBuzz;

public class FizzBuzzSolutionTests
{
    [Theory]
    [InlineData(5, 3, 5, new[] { "1", "2", "Fizz", "4", "Buzz" })]
    [InlineData(15, 3, 5, new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" })]
    [InlineData(1, 2, 3, new[] { "1" })]
    [InlineData(3, 1, 1, new[] { "FizzBuzz", "FizzBuzz", "FizzBuzz" })]
    [InlineData(5, 1, 2, new[] { "Fizz", "FizzBuzz", "Fizz", "FizzBuzz", "Fizz" })]
    public void FizzBuzz_ReturnsExpectedOutput_DefaultStrings(int n, int num1, int num2, string[] expected)
    {
        // Arrange
        var solution = new FizzBuzzSolution();

        // Act
        var result = solution.FizzBuzz(n, num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(GetCustomFizzBuzzTestCases))]
    public void FizzBuzz_CustomStrings_ReturnsExpectedOutput(int n, int num1, int num2, string str1, string str2, string[] expected)
    {
        // Arrange
        var solution = new FizzBuzzSolution();

        // Act
        var result = solution.FizzBuzz(n, num1, num2, str1, str2);

        // Assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetCustomFizzBuzzTestCases()
    {
        yield return new object[]
        {
            10, 2, 3, "Foo", "Bar",
            new[] { "1", "Foo", "Bar", "Foo", "5", "FooBar", "7", "Foo", "Bar", "Foo" }
        };

        yield return new object[]
        {
            6, 2, 4, "A", "B",
            new[] { "1", "A", "3", "AB", "5", "A" }
        };

        yield return new object[]
        {
            7, 1, 7, "One", "Seven",
            new[] { "One", "One", "One", "One", "One", "One", "OneSeven" }
        };
    }

    [Fact]
    public void FizzBuzz_InvalidArguments_ThrowsArgumentException()
    {
        // Arrange
        var solution = new FizzBuzzSolution();

        // Assert
        Assert.Throws<ArgumentException>(() => solution.FizzBuzz(0, 3, 5));
        Assert.Throws<ArgumentException>(() => solution.FizzBuzz(10, 0, 5));
        Assert.Throws<ArgumentException>(() => solution.FizzBuzz(10, 3, -1));
    }

    [Theory]
    [InlineData(100, 3, 5)]
    [InlineData(15, 2, 7)]
    [InlineData(50, 1, 2)]
    public void FizzBuzz_And_Alternative_ReturnSameResults(int n, int num1, int num2)
    {
        var solution = new FizzBuzzSolution();

        var result1 = solution.FizzBuzz(n, num1, num2);
        var result2 = solution.FizzBuzzAlternative(n, num1, num2);

        Assert.Equal(result1, result2);
    }
}
