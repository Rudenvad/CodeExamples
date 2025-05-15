namespace Examples.FizzBuzz;

public class FizzBuzzSolution
{
    /// <summary>
    /// Generates a list of strings from 1 to <paramref name="n"/>, replacing multiples of 
    /// <paramref name="num1"/> with <paramref name="str1"/>, multiples of 
    /// <paramref name="num2"/> with <paramref name="str2"/>, and multiples of both with their concatenation.
    /// </summary>
    /// <param name="n">The length of the result list.</param>
    /// <param name="num1">The first divisor for replacement.</param>
    /// <param name="num2">The second divisor for replacement.</param>
    /// <param name="str1">The string to replace multiples of <paramref name="num1"/>. Default is "Fizz".</param>
    /// <param name="str2">The string to replace multiples of <paramref name="num2"/>. Default is "Buzz".</param>
    /// <returns>A list of strings with appropriate replacements based on divisibility.</returns>
    /// <exception cref="ArgumentException">Thrown if any of <paramref name="n"/>, <paramref name="num1"/>, or <paramref name="num2"/> is less than or equal to zero.</exception>
    /// <example>
    /// FizzBuzz(16, 3, 5) returns:
    /// ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16"]
    /// </example>
    public List<string> FizzBuzz(int n, int num1, int num2, string str1 = "Fizz", string str2 = "Buzz")
    {
        if (n <= 0 || num1 <= 0 || num2 <= 0)
            throw new ArgumentException($"Arguments [{nameof(n)}, {nameof(num1)}, {nameof(num2)}] must be greater than zero!");

        string combinedStr = $"{str1}{str2}";

        var list = new List<string>();

        for (int i = 1; i <= n; i++)
        {
            var curr = i.ToString();

            if (i % num1 == 0 && i % num2 == 0)
            {
                curr = combinedStr;
            }
            else if (i % num1 == 0)
            {
                curr = str1;
            }
            else if (i % num2 == 0)
            {
                curr = str2;
            }

            list.Add(curr);
        }

        return list;
    }

    public List<string> FizzBuzzAlternative(int n, int num1, int num2, string str1 = "Fizz", string str2 = "Buzz")
    {
        if (n <= 0 || num1 <= 0 || num2 <= 0)
            throw new ArgumentException("Arguments must be greater than zero!");

        var list = new List<string>(capacity: n);  // Preallocate capacity

        for (int i = 1; i <= n; i++)
        {
            string result = string.Empty;

            if (i % num1 == 0) result += str1;
            if (i % num2 == 0) result += str2;

            list.Add(string.IsNullOrEmpty(result) ? i.ToString() : result);
        }

        return list;
    }
}
