using System;
using System.Threading;

namespace timebug_fixer
{
    class Program
    {
        static void Run(object proc)
        {
            GameHolder holder = new GameHolder((string)proc);
            while (true)
            {
                Thread.Sleep(100);
                holder.Refresh();
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Run));
            t.Start(args[0]);
            Console.WriteLine("Press any key at any time to close");
            Console.ReadKey();
            t.Abort();
        }
    }
}
