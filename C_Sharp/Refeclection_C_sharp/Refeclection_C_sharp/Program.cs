using System;
using System.Reflection;
class Program
{

    public void Change(ref int a, out int b)
    {
        a = 1100;
        b = 1200;
    }
    public static void Main(string[] args)
    {
        Type t = typeof(Refeclection_C_sharp.Students);

        Console.WriteLine("Class Name: " + t.Name);
        Console.WriteLine("Name Space : "+ t.Namespace);

        MethodInfo[] methods = t.GetMethods();
        Console.WriteLine("Methods:");

        foreach(MethodInfo method2 in methods)
        {
            Console.WriteLine(method2.Name);
        }

        MethodInfo[] methods1 = t.GetMethods(
        BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (MethodInfo method1 in methods1) { 
            Console.WriteLine("Methods1 :"+method1.Name);
        }

        object obj = Activator.CreateInstance(typeof(Refeclection_C_sharp.Students),new object[] { "Uday", "A", 101 });

         MethodInfo method = t.GetMethod("Display");
         method.Invoke(obj, null);

        int a = 20; int b;
        Program p = new Program();
        p.Change(ref a, out b);
        Console.WriteLine("a: " + a + ", b: " + b);
    }
}
