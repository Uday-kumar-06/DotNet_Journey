using Xunit;

public class CalculatorTests
{
    private CalculatorService calculatorService;

    public CalculatorTests()
    {
        calculatorService = new CalculatorService();
    }

    [Fact]
    public void Add_ShouldReturnCorrectResult()
    {
        var result = calculatorService.Add(2, 3);
        Assert.Equal(5, result);
    }
}