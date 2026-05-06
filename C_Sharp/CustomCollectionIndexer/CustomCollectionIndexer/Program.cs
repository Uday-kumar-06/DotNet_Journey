using CustomCollectionIndexer;

public class Program
{
    public static void Main(string[] args)
    {
        CustomCollection collection = new CustomCollection();
        try
        {
            
            for (int i = 0; i < 5; i++)
            {
                collection[i] = $"Item {i}";
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(collection[i]);
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
