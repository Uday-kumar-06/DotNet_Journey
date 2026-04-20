using C_Sharp_Delegates;

class Program
{
    public static void Main(String[] args)
    {
        Delegates obj1 = new Delegates();
        AddDelegate addDel = obj1.Add;

        Console.WriteLine(addDel(10, 12));
        AddDelegate subDel = obj1.Subtract;
        Console.WriteLine(subDel(10, 12));


        //multi casting Delegate
        MulticastDelegates obj2 = new MulticastDelegates();
        MyDelegate multiDel = obj2.M1;
        multiDel += obj2.M2;
        multiDel("Hello Guys");

        //MyReturnTyprDelegate multiReturnDel = obj2.M3;
        //multiReturnDel += obj2.M4;

        //Console.WriteLine(multiReturnDel(5));
    }
}