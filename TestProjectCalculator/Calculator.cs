namespace TestProjectCalculator;

public class Calculator
{
    private static void CalculateOperation(List<string> queryList, string operationSymbol, Func<double,double,double> calculatorHandler)
    {
        var indexOfOperation = queryList.IndexOf(operationSymbol);

        if (indexOfOperation == -1)
        {
            return;
        }

        while (indexOfOperation != -1 && queryList.Count >= 3)
        {
            try
            {
                var nextNumber = double.Parse(queryList[indexOfOperation + 1]);
                var prevNumber = double.Parse(queryList[indexOfOperation - 1]);

                var result = calculatorHandler(prevNumber, nextNumber);

                queryList.Insert(indexOfOperation + 2, result.ToString());

                queryList.RemoveRange(indexOfOperation - 1, 3);

            }
            catch (FormatException ex)
            {
                throw new CalculatorExceptionHandling(new FormatException());
            }

            indexOfOperation = queryList.IndexOf(operationSymbol);

        }
    }

    public static void Calculate(List<string> queryList)
    {
        Calculator.CalculateOperation(queryList, "*", CalculatorHandler.Multiply);
        Calculator.CalculateOperation(queryList, "/", CalculatorHandler.Divide);
        Calculator.CalculateOperation(queryList, "+", CalculatorHandler.Add);
        Calculator.CalculateOperation(queryList, "-", CalculatorHandler.Subtract);
    }
}