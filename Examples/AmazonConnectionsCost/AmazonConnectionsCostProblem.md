# AmazonConnectionsCost

Description:
In Amazon's highly efficient logistics network, minimizing operational overhead and optimizing package routing is crucial to ensure smooth deliveries across various regions.
The network consists of `n` warehouses, numbered from `1` to `n`, each strategically positioned at its corresponding index.
Each warehouse has a specific storage capacity, given by `warehouseCapacity`, where `warehouseCapacity[i]` represents the capacity of the warehouse located at position i (assuming 1-based indexing).

These warehouses are organized in a `non-decreasing` order of their storage capacities, meaning each warehouse's storage capacity is greater than or equal to the one before it.
Each warehouse must establish a connection to a distribution hub positioned at a location greater than or equal to its own. This means that a warehouse at position `i` can only connect to a hub at position `j`, where `j  >= i`.

To optimize inventory routing, Amazon has placed a central high-capacity distribution hub at the last warehouse, located at position `n`.
This hub serves as the main connection point for all warehouses if necessary.
The cost of establishing a connection from warehouse at `i` to a hub at position `j` is given by `warehouseCapacity[j] - warehouseCapacity[i]`.

Given `q` queries of the form (hubA, hubB), where two additional high-performance distribution hubs are deployed at warehouses hubA and hubB (`1 <= hubA < hubB < n`), the goal is to calculate the minimum total connection cost for all warehouses, considering the nearest available distribution hub at or beyond each warehouse's position.

**Note:**
- The problem statement assumes 1-based indexing for the `warehouseCapacity` array.
- Each query is independent i.e., the changes made do not persist for subsequent queries.
- Each warehouse connects to the nearest hub at or beyond its position (either hubA hubB, or the central hub at `n`) to minimize the overall connection cost.

## Example
```
n = 5
warehouseCapacity = [3, 6, 10, 15, 20]
q = 1
additionalHubs = [[2,4]]
```

In this case there is `q = 1` query with two additional high-performance distribution hubs at position `hubA = 2` and `hubB = 4`.
This diagram shows the calculation of the total connection cost before additional distribution hubs are considered:
`[warehouseCapacity] => [3]`
```

[3]	[6]	[10]	[15]	[20 | Distribution hub]
			<----cost = 20-15 = 5--------->
		<----cost = 20-10 = 10---------------->
	<----cost = 20-6 = 14------------------------->
<----cost = 20-3 = 17--------------------------------->

After query 1: Additional distribution hubs installed at positions hubA 2 and hubB 4
[3]	[6 | Distribution hub]	[10]	[15 | Distribution hub]	[20 | Distribution hub]
<----cost = 6-3 = 3---->	<----cost = 15-10 = 5---->
```
- Once additional distribution hubs are installed at positions hubA = 2 and hubB = 4:
  - 1st warehouse will connect to the nearest available distribution hub at position 2, cost incurred = 6 - 3 = 3
  - 2nd warehouse is itself a distribution hub, so cost incurred = 0
  - 3rd warehouse will connect to the nearest available distribution hub at position 4, cost incurred = 15 - 10 = 5
  - 4th and 5th warehouses are itself a distribution hub, so cost incurred = 0 + 0 = 0

Thus, the total connection cost = `(6-3) + (0) + (15- 10) + (0) + (0) = 8`.
Hence, return `[8]` as the answer.

## Function Description
Complete the function `getMinConnectionCost` in the editor below.
`getMinConnectionCost` has the following parameter(s):
- int warehouseCapacity[n]: a non-decreasing array of integers representing the storage capacities of the warehouses
- int additionalHubs[q][2]: an array where each element denotes the positions of two additional distribution hubs installed for a query

**Returns** `long_int[q]`: the answers for each query

# Constraints:
- `3 <= n <= 2.5 * 10^5`
- `1 <= q <= 2.5 * 10^5`
- `0 <= warehouseCapacity[i] <= 10^9`
- `warehouseCapacity[i] <= warehouseCapacity[i+1]` for all `0 <= i < n-1`
- `1 <= additionalHubs[i][0] < additionalHubs[i][1] < n`

# Input Format For Custom Testing
The first line contains an integer, `n`, the number of elements in `warehouseCapacity`.
Each line `i` of the `n` subsequent lines (where `0 <= i < n`) contains an integer, `warehouseCapacity[i1`.
The next line contains an integer, `q` the number of rows in `additionalHubs`.
The next line contains an integer, `2`, the number of columns in `additionalHubs`.
Each line `i` of the `q` subsequent lines (where `0 <= i < n`) contains 2 space-separated integers, `additionalHubs[i][0]` and `additionalHubs[i][1]`

# Sample Case 0
Sample Input For Custom Testing
```
STDIN		FUNCTION
-----		--------
6	->	warehouseCapacity[] size n = 6
0	->	warehouseCapacity = [0, 2, 5, 9, 12, 18]
2
5
9
12
18
2	-> number of queries q = 2
2	-> number of columns = 2
2 5	-> additionalHubs = [[2, 5], [1, 3]]
1 3
```
Sample Output
```
12
18
```
Explanation
In this case we have `n = 6`, `warehouseCapacity = [0, 2, 5, 9, 12, 18]`, `q = 2`, `additionalHubs = [[2, 5], [1, 3]]`
- Since we have initially 1 central hub at position `n`. So total connection cost = `(18-0) + (18-2) + (18-5) + (18-9) + (18-12) + (18-18) = 62`.
- In first query, we build 2 additional distribution hubs at positions 2 and 12. Now:
  - 1st warehouse will connect to the nearest available distribution hub at position 2, cost incurred = 2-0 = 2
  - 2nd warehouse is itself a distribution hub, so cost incurred = 0
  - 3rd warehouse will connect to the nearest available distribution hub at position 5, cost incurred = 12-5 = 7
  - 4th warehouse will connect to the nearest available distribution hub at position 5, cost incurred = 12-9 = 3
  - 5th warehouse is itself a distribution hub, so cost incurred = 0
  - 6th warehouse is itself a distribution hub, so cost incurred = 0
  - Thus the total connection cost = 2 + 0 + 7 + 3 + 0 + 0 = 12.
- In second query, we build 2 additional distribution hubs at positions 1 and 3. Now:
  - 1st warehouse is itself a distribution hub, so cost incurred = 0
  - 2nd warehouse will connect to the nearest available distribution hub at position 3, cost incurred = 5-2 = 3
  - 3rd warehouse is itself a distribution hub, so cost incurred = 0
  - 4th warehouse will connect to the nearest available distribution hub at position 6, cost incurred = 18-9 = 9
  - 5th warehouse will connect to the nearest available distribution hub at position 6, cost incurred = 18-12 = 6
  - 6th warehouse is itself a distribution hub, so cost incurred = 0
  - Thus the total connection cost = 0 + 3 + 0 + 9 + 6 + 0 = 18.

Thus, the answer is [12, 18].

# Sample Case 1
Sample Input For Custom Testing
```
STDIN		FUNCTION
-----		--------
4	->	warehouseCapacity[] size n = 6
2	->	warehouseCapacity = [0, 2, 5, 9, 12, 18]
6
8
14
1	-> number of queries q = 1
2	-> number of columns = 2
1 2	-> additionalHubs = [[1, 2]]
```
Sample Output
```
6
```
Explanation
In this case we have `n = 4`, `warehouseCapacity = [2, 6, 8, 14]`, `q = 1`, `additionalHubs = [[1, 2]]`
- Initially, there is 1 distribution hub at warehouse number `n`. So distance travelled is `(14-2) + (14-6) + (14-8) + (14-14) = 26`.
- In first query, we build 2 additional distribution hubs at positions 1 and 2. Now:
  - 1st warehouse is itself a distribution hub, so cost incurred = 0
  - 2nd warehouse is itself a distribution hub, so cost incurred = 0
  - 3rd warehouse will connect to the nearest available distribution hub at position 4, cost incurred = 14-8 = 6
  - 4th warehouse is itself a distribution hub, so cost incurred = 0
  - Thus the total connection cost = 0 + 0 + 6 + 0 = 6.

Thus, the answer is `[6]`.

# Code
```
class Result
{

    /*
     * Complete the 'getMinConnectionCost' function below.
     *
     * The function is expected to return a LONG_INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY warehouseCapacity
     *  2. 2D_INTEGER_ARRAY additionalHubs
     */

    public static List<long> getMinConnectionCost(List<int> warehouseCapacity, List<List<int>> additionalHubs)
    {

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int warehouseCapacityCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> warehouseCapacity = new List<int>();

        for (int i = 0; i < warehouseCapacityCount; i++)
        {
            int warehouseCapacityItem = Convert.ToInt32(Console.ReadLine().Trim());
            warehouseCapacity.Add(warehouseCapacityItem);
        }

        int additionalHubsRows = Convert.ToInt32(Console.ReadLine().Trim());
        int additionalHubsColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> additionalHubs = new List<List<int>>();

        for (int i = 0; i < additionalHubsRows; i++)
        {
            additionalHubs.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(additionalHubsTemp => Convert.ToInt32(additionalHubsTemp)).ToList());
        }

        List<long> result = Result.getMinConnectionCost(warehouseCapacity, additionalHubs);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
```