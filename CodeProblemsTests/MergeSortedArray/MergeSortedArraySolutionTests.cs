using CodeProblems.MergeSortedArray;

namespace CodeProblemsTests.MergeSortedArray;

public class MergeSortedArraySolutionTests
{
    [Theory]
    [MemberData(nameof(GetTestCases))]
    public void Merge_TwoArrays_ResultsMergedArray(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        // Arrange
        var solution = new MergeSortedArraySolution();

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    public static IEnumerable<object[]> GetTestCases()
    {
        yield return new object[] { new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 } };
        yield return new object[] { new int[] { 1, 0, 0, 0 }, 1, new int[] { 2, 3, 4 }, 3, new int[] { 1, 2, 3, 4 } };
        yield return new object[] { new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 } };
        yield return new object[] { new int[] { 1 }, 1, new int[] { }, 0, new int[] { 1 } };
        yield return new object[] { new int[] { 2, 0 }, 1, new int[] { 1 }, 1, new int[] { 1, 2 } };
        yield return new object[] { new int[] { 4, 5, 6, 0, 0, 0 }, 3, new int[] { 1, 2, 3 }, 3, new int[] { 1, 2, 3, 4, 5, 6 } };
    }
}
