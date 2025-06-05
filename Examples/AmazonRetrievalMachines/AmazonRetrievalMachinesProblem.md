# Amazon Retrieval Machines

Description:
An analyst in the logistics team of Amazon e-commerce was reviewing the efficiency metrics of the new automated stocking and retrieval machines.
They went about their calculations in the following manner:

A sequence of `n` machines is tasked with stocking or retrieving items.
Given the individual stocking/retrieving capacity values of each machine as an integer array, `machineCapacity`.

The _Efficiency_ of this sequence is evaluated using a comparison metric: the sum of the absolute difference between consecutive machine capacities.
```
Efficiency = ∑ (from i = 0 to n - 2) |machineCapacity[i] - machineCapacity[i + 1]|
```

The task is to determine whether achieving the same sum of the absolute difference is possible by removing some machines from the sequence to streamline the operations.
If it is possible, return the minimum number of machines required in the sequence to attain the same sum of the absolute difference between consecutive machine capacities.

**Note:** The efficiency score of a sequence consisting of only one machine is 0.

## Example
```
n = 5
machineCapacity = [1,2,2,1,1]

[1][2][2][1][1] -> [1][2][1]
```

Efficiency initially: |1-2| + |2-2| + |2-1| + |1-1| = 2
Efficiency after removal: |1-2| + |2-1| = 2

It can be seen that after the removal of these 2 machines, we obtain the same efficiency

Thus, the answer in this case is 3.
It can be proven that the answer can't be less than 3.

## Function Description
Complete the function `findMinimumMachinesSize` in the editor below.
`findMinimumMachinesSize` has the following parameter(s):
- int machineCapacity[n]: the stocking/retrieval capacity of each machine

# Constraints:
- `1 <= n <= 2 * 10^5`
- `0 <= machineCapacity[i] <= 10^9`

# Input Format For Custom Testing
The first line contains an integer, `n`, the number of machines in the sequence.
Each line `i` of the `n` subsequent lines (where `0 <= i < n`) contains an integer, machineCapacity[i].

# Sample Case 0
Sample Input For Custom Testing
```
STDIN		FUNCTION
-----		--------
6	->	machineCapacity[] size n = 6
5	->	machineCapacity = [5, 4, 0, 3, 3, 1]
4
0
3
3
1
```
Sample Output
```
4
```
Explanation
Efficiency initially: |5-4| + |4-0| + |0-3| + |3-3| + |3-1| = 10
```
[5][4][0][3][3][1] -> [5][0][3][1]
```
Efficiency after removal: |5-0| + |0-3| + |3-1| = 10
It can be seen that after the removal of these 2 machines, we obtain the same efficiency. 
It can be shown that on removing any other machine, the efficiency changes.
Thus, the answer in this case is 4.

# Sample Case 1
Sample Input For Custom Testing
```
STDIN		FUNCTION
-----		--------
4	->	machineCapacity[] size n = 4
5	->	machineCapacity = [5, 2, 2, 0]
2
2
0
```
Sample Output
```
2
```
Explanation
Efficiency initially: |5-2| + |2-2| + |2-0| = 5
```
[5][2][2][0] -> [5][0]
```
Efficiency after removal: |5-0| = 5
It can be seen that after the removal of these 2 machines, we obtain the same efficiency. 
It can be shown that on removing any other machine, the efficiency changes.
Thus, the answer in this case is 2.

# Code
```
class Result
{    
    public static int findMinimumMachinesSize(List<int> machineCapacity)
    {
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int machineCapacityCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> machineCapacity = new List<int>();

        for (int i = 0; i < machineCapacityCount; i++)
        {
            int machineCapacityItem = Convert.ToInt32(Console.ReadLine().Trim());
            machineCapacity.Add(machineCapacityItem);
        }

        int result = Result.findMinimumMachinesSize(machineCapacity);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
```