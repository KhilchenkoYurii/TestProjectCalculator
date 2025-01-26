namespace TestProjectCalculator;

public class Calculator
{
    public double Calculate(List<string> queryList, string operationSymbol, Func<double,double,double> calculatorHandler)
    {
        var result = 0.0d;

        var indexOfOperation = queryList.IndexOf(operationSymbol);

        if (indexOfOperation == -1)
        {
            return 0.0;
        }

        while (indexOfOperation != -1 && queryList.Count >= 3)
        {
            try
            {
                var nextNumber = double.Parse(queryList[indexOfOperation + 1]);
                var prevNumber = double.Parse(queryList[indexOfOperation - 1]);

                result = calculatorHandler(prevNumber, nextNumber);

                queryList.Insert(indexOfOperation + 2, result.ToString());

                queryList.RemoveRange(indexOfOperation - 1, 3);

            }
            catch (Exception ex)
            {
                throw new Exception("Invalid query");
            }
            indexOfOperation = queryList.IndexOf(operationSymbol);

        }

        return result;
    }
}