# FizzBuzz

Write a function that returns a list of strings representing the numbers from `1` to `n`.

But for multiples of a given number `num1`, insert the string `str1` instead of the number, and for the multiples of a given number `num2`, insert the string `str2`.

For numbers which are multiples of **both `num1` and `num2`**, insert the concatenation of `str1` and `str2`.

The function should not print the result, but instead return a list of strings that can be tested or printed externally.

## Function Signature:
```csharp
public List<string> FizzBuzz(int n, int num1, int num2, string str1 = "Fizz", string str2 = "Buzz")
```

## Example 1:
```
Input: n = 15, num1 = 3, num2 = 5
Output: ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]
Explanation: Numbers divisible by 3 are replaced with "Fizz", by 5 with "Buzz", and by both with "FizzBuzz".
```

## Example 2:
```
Input: n = 10, num1 = 2, num2 = 3, str1 = "Foo", str2 = "Bar"
Output: ["1", "Foo", "Bar", "Foo", "5", "FooBar", "7", "Foo", "Bar", "Foo"]
Explanation: Replacements are made using custom labels "Foo" and "Bar".
```

## Example 3:
```
Input: n = 5, num1 = 1, num2 = 2
Output: ["Fizz", "FizzBuzz", "Fizz", "FizzBuzz", "Fizz"]
Explanation: Every number is divisible by 1 ("Fizz"), and even numbers are also divisible by 2 ("Buzz"). So every second number becomes "FizzBuzz".
```

# Constraints:
- `str1`, `str2` are non-empty strings
- Output should contain exactly `n` elements
- Throws `ArgumentException` if `n <= 0`, `num1 <= 0`, `or num2 <= 0`
