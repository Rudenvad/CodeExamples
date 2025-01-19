namespace CodeProblems.RemoveElement;

public class RemoveElementSolution
{
    public int RemoveElement(int[] nums, int val)
    {
        int leftPointer = 0;
        int rightPointer = nums.Length - 1;

        while (leftPointer <= rightPointer)
        {
            if (nums[leftPointer] == val)
            {
                // Swap only if leftPointer points to the value to be removed
                nums[leftPointer] = nums[rightPointer];
                nums[rightPointer] = val;  // Optional, only to mark that position

                // Move rightPointer leftwards
                rightPointer--;
            }
            else
            {
                // If the leftPointer is not the value to be removed, just move it forward
                leftPointer++;
            }
        }

        return leftPointer;  // The new length of the array
    }
}
