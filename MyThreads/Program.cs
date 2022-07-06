using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThreads
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }




        public void Test()
        {
            for (int i = 0; i < 10000; i++)
            {
                var thread = new Thread(() =>
                {
                    Thread.Sleep(10);
                    Console.WriteLine($"Id:{Thread.CurrentThread.ManagedThreadId},执行");
                });
                thread.Start();
            }
            Console.ReadLine();
        }

    }
}
