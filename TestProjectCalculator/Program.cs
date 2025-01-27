using System.Linq;
using System.Text.RegularExpressions;

namespace TestProjectCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please, input your query (like 2 + 1) and press Enter:");

        var inputQuery = Console.ReadLine();

        CheckInput(inputQuery);

        var splitQuery = inputQuery.Split(' ');

        CheckInputArray(splitQuery);

        List<string> queryList = new List<string>(splitQuery);

        Calculator.Calculate(queryList);

        Console.WriteLine($"Result: {CheckResult(queryList)}");

    }

    private static void CheckInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new CalculatorExceptionHandling(new NullReferenceException());
        }

        if (input.Length < 3)
        {
            throw new CalculatorExceptionHandling(new ArgumentException());
        }
    }

    private static void CheckInputArray(string[] inputArray)
    {
        if (string.IsNullOrEmpty(inputArray[0]))
        {
            throw new CalculatorExceptionHandling(new NullReferenceException());
        }

        if (inputArray.Length < 3)
        {
            throw new CalculatorExceptionHandling(new ArgumentException()); ;
        }
    }

    private static double CheckResult(List<string> resultList)
    {
        if (resultList.Count > 1)
        {
            throw new CalculatorExceptionHandling(new ArgumentException(), "Incorrect query!"); ;
        }

        try
        {
            var result = double.Parse(resultList[0]);

            return result;
        }
        catch (FormatException ex)
        {
            throw new CalculatorExceptionHandling(new FormatException());
        }
    }
}