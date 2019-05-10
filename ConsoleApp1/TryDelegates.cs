using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DerekBanas
{
    public delegate int BinaryOp(ref int x, ref int y);

    public class SimpleMath
    {
        public static int Add(ref int x, ref int y) => x += y ;
        public static int Subtract(ref int x, ref int y) => x -= 3* y;
    }

    class TryDelegates
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("**** Simple Delegate Example ****\n");

        //    BinaryOp b = new BinaryOp(SimpleMath.Add);
        //    b += SimpleMath.Subtract;

        //    int x = 20, y = 2;

        //    int result = b(ref x, ref y);

        //    Console.WriteLine("Result {0}", result);
        //    Console.WriteLine("X {0} Y {1}", x, y);
        //    Console.ReadLine();
        //}
    }
}
