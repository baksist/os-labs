using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace os_lab_3
{
    class Program
    {
        private const int producers = 3;
        private const int consumers = 2;
        private const int capacity = 200;
        private static AutoResetEvent produce_handle = new AutoResetEvent(true);
        private static AutoResetEvent consume_handle = new AutoResetEvent(true);

        private static bool stop_producers = false;

        private static BlockingCollection<int> queue = new BlockingCollection<int>(capacity);
        
        static void Main(string[] args)
        {
            var prod_threads = new Thread[producers];
            var cons_threads = new Thread[consumers];

            /*for (var i = 0; i < producers; i++)
            {
                produce_handles[i] = new AutoResetEvent(true);
            }*/
            for (var i = 0; i < producers; i++)
            {
                prod_threads[i] = new Thread(Produce){Name = $"Producer {i}"};
                prod_threads[i].Start();
            }

            for (var i = 0; i < consumers; i++)
            {
                cons_threads[i] = new Thread(Consume){Name = $"Consumer {i}"};
                cons_threads[i].Start();
            }

            /*/*char c = Char.MaxValue;
            while (c != 'q')
                c = Console.ReadKey().KeyChar;#1#
            Thread.Sleep(10000);
            stop_producers = true;*/

            while (true)
            {
                var c = Console.Read();
                if (c == 'q')
                    break;
            }

            stop_producers = true;

        }

        // TODO: pause all producer threads on condition
        private static void Produce()
        {
            var rnd = new Random();

            while (true)
            {
                queue.Add(rnd.Next(1,100));
                Console.WriteLine($"{queue.Count}: element added by {Thread.CurrentThread.Name}");
                Thread.Sleep(300);
                if (queue.Count >= 100)
                {
                    
                    // var index = Thread.CurrentThread.Name.Last() - 48;
                    // Console.WriteLine(index);
                    Console.WriteLine($"Too many elements, {Thread.CurrentThread.Name} sleeps");
                    produce_handle.WaitOne();
                }

                if (stop_producers)
                    return;
            }
        }

        // TODO: implement wait when queue is empty
        private static void Consume()
        {
            while (true)
            {
                var n = queue.Take();
                Console.WriteLine($"{queue.Count}: element taken by {Thread.CurrentThread.Name}");
                Thread.Sleep(500);
                if (queue.Count <= 80)
                {
                    produce_handle.Set();
                }

                if (queue.Count >= 95)
                    consume_handle.WaitOne();

                if (queue.Count <= 0)
                    break;
            }
        }
    }
}