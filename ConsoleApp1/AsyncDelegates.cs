using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleApp_DerekBanas
{
    class AsyncDelegates
    {
        public delegate int BinaryOp(int x, int y);
        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}",
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("DONE IN ADD!");
            return x + y;
        }
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main thread {0}",
        //        Thread.CurrentThread.ManagedThreadId);

        //    BinaryOp b = new BinaryOp(Add);
        //    IAsyncResult ar = b.BeginInvoke(10, 10, null, null);

        //    //while(!ar.IsCompleted)
        //    //{
        //    //    Console.WriteLine("Doing more work in Main()!");
        //    //    Thread.Sleep(1000);
        //    //}
        //    while (!ar.AsyncWaitHandle.WaitOne(1000, true))
        //    {
        //        Console.WriteLine("Doing more work in Main()!");
        //    }

        //    int answer = b.EndInvoke(ar);
        //    Console.WriteLine("Answer is {0}", answer);
        //}
    }
}
