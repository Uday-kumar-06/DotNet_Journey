class MyException : Exception
{
    public MyException (string message): base(message)
    {
    }
}
class Program
{
    public static void Main()
    {
        int num = 1;
        try
        {
            if (num > 10)
            {
                throw new MyException("This is a custom exception.");
            }

            int num2 = 0;
            int result = num / num2;
        }
        catch (MyException ex)
        {
            Console.WriteLine($"Caught an exception: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Caught a divide by zero exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught a general exception: {ex.Message}");
        }

    }
}
