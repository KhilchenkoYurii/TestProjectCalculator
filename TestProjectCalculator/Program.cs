using System.Linq;
using System.Text.RegularExpressions;

namespace TestProjectCalculator;

public class Program
{
    public const string RegexString = @"[0-9\+\*\/\ \-]";
    public static void Main(string[] args)
    {
        Console.WriteLine("Please, input your query (like 2 + 1) and press Enter");

        var inputQuery = Console.ReadLine();

        if (string.IsNullOrEmpty(inputQuery))
        {
            throw new CalculatorExceptionHandling(new NullReferenceException());
        }

        var regex = new Regex(RegexString);

        if (!Regex.Match(inputQuery,RegexString).Success)
        {
            throw new CalculatorExceptionHandling(new ArgumentException(), "Incorrect query");
        }

        if (inputQuery.Length < 3)
        {
            throw new CalculatorExceptionHandling(new ArgumentException());
        }

        var splitQuery = inputQuery.Split(' ');

        if (string.IsNullOrEmpty(splitQuery[0]))
        {
            throw new CalculatorExceptionHandling(new NullReferenceException());
        }

        if (splitQuery.Length < 3)
        {
            throw new CalculatorExceptionHandling(new ArgumentException()); ;
        }

        List<string> queryList = new List<string>(splitQuery);

        Calculator.Calculate(queryList);

        try
        {
            var result = double.Parse(queryList[0]);

            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException ex)
        {
            throw new CalculatorExceptionHandling(new FormatException());
        }

    }
}