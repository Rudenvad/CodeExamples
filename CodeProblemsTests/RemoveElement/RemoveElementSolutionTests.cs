using CodeProblems.RemoveElement;

namespace CodeProblemsTests.RemoveElement;

public class RemoveElementSolutionTests
{
    [Theory]
    [InlineData(new int[] { 3, 2, 2, 3 }, 3, 2)]  // Expected: 2 remaining elements, [2, 2]
    [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]  // Expected: 5 remaining elements, [0, 1, 3, 0, 4]
    [InlineData(new int[] { 1, 1, 1 }, 1, 0)]  // Expected: 0 remaining elements, []
    [InlineData(new int[] { 4, 5, 6 }, 7, 3)]  // Expected: 3 remaining elements, [4, 5, 6] (no change)
    [InlineData(new int[] { }, 5, 0)]  // Expected: 0 remaining elements, [] (empty array)
    public void RemoveElement_ReturnsExpectedLength(int[] nums, int val, int expectedLength)
    {
        // Arrange
        var solution = new RemoveElementSolution();

        // Act
        var result = solution.RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedLength, result);
    }

    [Theory]
    [MemberData(nameof(GetTestCases))]
    public void RemoveElementMemberDataTest(int[] nums, int val, int expectedLength, int[] expectedValues)
    {
        // Arrange
        var solution = new RemoveElementSolution();

        // Act
        var result = solution.RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedLength, result);

        // Sort the first k elements (according to custom judge)
        var firstKElements = nums.Take(result).OrderBy(x => x).ToArray();

        // Compare the first k elements with the expected sorted values
        Assert.Equal(expectedValues.OrderBy(x => x), firstKElements);
    }

    public static IEnumerable<object[]> GetTestCases()
    {
        yield return new object[] { new int[] { 3, 2, 2, 3 }, 3, 2, new int[] { 2, 2 } };
        yield return new object[] { new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5, new int[] { 0, 1, 3, 0, 4 } };
        yield return new object[] { new int[] { 1, 1, 1 }, 1, 0, new int[] { } };  // All elements removed
        yield return new object[] { new int[] { 4, 5, 6 }, 7, 3, new int[] { 4, 5, 6 } };  // No elements removed
        yield return new object[] { new int[] { }, 5, 0, new int[] { } };  // Empty array
    }
}
