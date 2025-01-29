using System.Linq;
using System.Text.RegularExpressions;

namespace TestProjectCalculator;

public class Program
{
    public static readonly char[] AllowedOperations = ['+', '-', '*', '/'];
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Please, input your query (like 2 + 1) and press Enter or type E to exit:");

            var inputQuery = Console.ReadLine();



            if (inputQuery == "E")
            {
                break;
            }

            CheckInput(inputQuery);

            var trimInput = inputQuery.Replace(" ", string.Empty);
            var operations = new List<char>();

            for (int i = 0; i < trimInput.Length; i++)
            {
                if (!AllowedOperations.Contains(trimInput[i]))
                {
                    if (!Char.IsDigit(trimInput[i]))
                    {
                        throw new CalculatorExceptionHandling("Query can contain only digits and operations +, -, *, /");
                    }
                }
                else
                {
                    operations.Add(trimInput[i]);
                }
            }

            var splitQuery = inputQuery.Split(AllowedOperations);
            
            CheckInputArray(splitQuery);

            List<string> queryList = new List<string>(splitQuery);

            for (int i = 0; i < operations.Count; i++)
            {
                queryList.Insert(2 * i + 1, operations[i].ToString());
            }

            Calculator.Calculate(queryList);

            Console.WriteLine($"Result: {CheckResult(queryList)}");
        }


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