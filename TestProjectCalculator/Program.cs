namespace TestProjectCalculator;

public class Program
{
    public static readonly char[] AllowedSpecialSymbols = ['+', '-', '*', '/', '(', ')'];

    public static void Main(string[] args)
    {
        Console.WriteLine("Please, input your query (like 2 + 1)");

        var inputQuery = Console.ReadLine();

        var splitedQuery = inputQuery.Split(' ');

        var result = 0.0d;

        if (splitedQuery.Length < 3)
        {
            throw new Exception("Invalid query");
        }

        List<string> queryList = new List<string>(splitedQuery);

        Calculator calculator = new Calculator();

        calculator.Calculate(queryList, "*", CalculatorHandler.Multiply);
        calculator.Calculate(queryList, "/", CalculatorHandler.Divide);
        calculator.Calculate(queryList, "+", CalculatorHandler.Add);
        calculator.Calculate(queryList, "-", CalculatorHandler.Multiply);

        result = double.Parse(queryList[0]);

        Console.WriteLine($"Result: {result}");
    }
}