/* Problem: In C# create a console app that finds the Missing Number using SOLID principles
Description: Given an array containing numbers taken from the range 0 to n, find the one number that is missing from the array.

Input:
An array of integers number where nums contains n distinct numbers from the range 0 to n.

Output:
Return the missing number.

Examples:
Input: [3, 0, 1]
Output: 2

Input: [9, 6, 4, 2, 3, 5, 7, 0, 1]
Output: 8 */


// Goal: To Use SOLID Principle for the problem

// Program Entry
class Program
{
    static void Main(string[] args)
    {
        int[] input1 = { 3, 0, 1 };
        int[] input2 = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

        IMissingElement missingElement = new MissingElement();
        MissingNumberApp app = new MissingNumberApp(missingElement);

        Console.WriteLine("Example 1:");
        app.Run(input1);
        Console.WriteLine();
        Console.WriteLine("Example 2:");
        app.Run(input2);

        Console.ReadLine();
    }
}

// 1 - Interface Seggregation Principle - Seggregate the finding behaviour out of the finding logic
public interface IMissingElement
{
    int FindMissingElement(int[] nums);
}


// 2 - Single Responsibility Principle
public class MissingElement : IMissingElement
{
    public int FindMissingElement(int[] nums)
    {
        int n = nums.Length;
        int expectedSum = n * (n + 1) / 2;
        int actualSum = nums.Sum();

        return expectedSum - actualSum;
    }
}


public class MissingNumberApp
{
    private readonly IMissingElement _missingElement;

    public MissingNumberApp(IMissingElement missingElement)
    {
        _missingElement = missingElement;
    }

    public void Run(int[] input)
    {
        int missingElement = _missingElement.FindMissingElement(input);
        Console.WriteLine($"Missing Element: {missingElement}");
    }
}