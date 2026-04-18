class Program{
    public static void Main(string[] args)
    {
        //List
        List<string> names = new List<string>();

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            names.Add(name);
        }

        foreach(string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
