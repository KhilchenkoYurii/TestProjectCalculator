namespace TestProjectCalculator;

public class CalculatorExceptionHandling : Exception
{
    public CalculatorExceptionHandling(NullReferenceException ex)
    {
        Console.WriteLine("Query is empty!");
    }

    public CalculatorExceptionHandling(ArgumentException ex)
    {
        Console.WriteLine("Query is too short!");
    }

    public CalculatorExceptionHandling(ArgumentException ex, string message)
    {
        Console.WriteLine(message);
    }

    public CalculatorExceptionHandling(FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }

    public CalculatorExceptionHandling(string ex)
    {
        Console.WriteLine(ex);
    }
}