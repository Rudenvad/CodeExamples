namespace CodeProblems.MergeSortedArray;

public class MergeSortedArraySolution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        #region Pointers initialization
        // Pointer for the last valid element in nums1
        int nums1Pointer = m - 1;

        // Pointer for the last element in nums2
        int nums2Pointer = n - 1;

        // Pointer for the position where the next largest element should be placed
        int mergePointer = m + n - 1;
        #endregion Pointers initialization

        // Merge nums1 and nums2 starting from the largest elements
        while (nums1Pointer >= 0 && nums2Pointer >= 0)
        {
            // Compare the current largest elements from both arrays
            if (nums1[nums1Pointer] > nums2[nums2Pointer])
            {
                // Place the larger element at the merge position
                nums1[mergePointer] = nums1[nums1Pointer];
                nums1Pointer--;
            }
            else
            {
                // Place the larger element from nums2 at the merge position
                nums1[mergePointer] = nums2[nums2Pointer];
                nums2Pointer--;
            }
            // Move the merge pointer to the next position
            mergePointer--;
        }

        // If any elements remain in nums2, copy them into nums1
        while (nums2Pointer >= 0)
        {
            nums1[mergePointer] = nums2[nums2Pointer];
            nums2Pointer--;
            mergePointer--;
        }

        // Note: Remaining elements in nums1 are already in place, so no need to handle them
    }
}
