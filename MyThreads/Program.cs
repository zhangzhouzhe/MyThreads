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
        private Resource res = new Resource();
        static void Main(string[] args)
        {


            Thread.CurrentThread.Name = "Main";

            var p = new Program();
            var work = new Thread(p.ThreadEntry);
            work.Name = "Worker";
            work.Start();
            p.ThreadEntry();
            Console.ReadLine();
        }


        void ThreadEntry()
        {
            Monitor.Enter(res);
            res.Record();
            Monitor.Exit(res);
        }

        public void Test()
        {
            for (int i = 0; i < 10000; i++)
            {
                var thread = new Thread(() =>
                {
                    Thread.Sleep(10);
                    Console.WriteLine($"Id:{Thread.CurrentThread.Name},执行");
                });
                thread.Start();
            }
            Console.ReadLine();
        }

    }

    public class Resource
    {
        public string Called;
        public void Record()
        {
            Called += $"{Thread.CurrentThread.Name}[{DateTime.Now.Millisecond}]";
            Console.WriteLine(Called);
        }
    }
}
