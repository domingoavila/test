using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComposableDelegates
{
    // DelegateNormal
    public delegate void MyDelegate(int arg1, int arg2);

    // Delegate Ref
    public delegate void MyDelegateRef(int arg1, ref int arg2);

    class Program
    {
        // Delegate Normal
        static void func1(int arg1, int arg2)
        {
            string result = (arg1 + arg2).ToString();
            Console.WriteLine("The number is: " + result);
        }
        static void func2(int arg1, int arg2)
        {
            string result = (arg1 * arg2).ToString();
            Console.WriteLine("The number is: " + result);
        }

        // Delegate Ref
        static void func3(int arg1, ref int arg2)
        {
            string result = (arg1 + arg2).ToString();
            arg2 += 20; // arg2 is a ref parameter, so this will change it
            Console.WriteLine("The number is: " + result);
        }

        static void func4(int arg1, ref int arg2)
        {
            string result = (arg1 * arg2).ToString();
            Console.WriteLine("The number is: " + result);
        }

        static void Main(string[] args)
        {
            //CompositDelegate();
            CompositDelegateRef();

            Console.WriteLine("\nPress Enter Key to Continue...");
            Console.ReadLine();
        }

        static void CompositDelegate()
        {
            MyDelegate f1 = func1;
            MyDelegate f2 = func2;
            MyDelegate f1f2 = f1 + f2;

            // call each delegate and then the chain
            Console.WriteLine("Calling the first delegate");
            f1(10, 20);
            Console.WriteLine("Calling the second delegate");
            f2(10, 20);
            Console.WriteLine("\nCalling the chained delegates");
            f1f2(10, 20);

            // subtract off one of the delegates
            Console.WriteLine("\nCalling the unchained delegates");
            f1f2 -= f1;
            f1f2(20, 20);
        }

        static void CompositDelegateRef()
        {
            int a = 10, b = 10;
            MyDelegateRef f3 = func3;
            MyDelegateRef f4 = func4;
            MyDelegateRef combined = f3 + f4;

            Console.WriteLine("The value of b is: {0}", b);
            combined(a, ref b);
            Console.WriteLine("The value of b is: {0}", b);
        }
    }
}
