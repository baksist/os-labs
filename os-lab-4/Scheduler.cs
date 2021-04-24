using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace os_lab_4
{
    public static class Scheduler
    {
        private const int ProcessNumber = 5;
        private const int BASE_QUANTUM = 1000;
        private const ConsoleKey defaultKey = ConsoleKey.A;
        
        private static Queue<ProcessInfo> ProcessQueue;
        private static ConsoleKey key = defaultKey;
        
        public static int ProcessCount() => ProcessQueue.Count;
        
        public static void Initialize()
        {
            try
            {
                ProcessQueue = new Queue<ProcessInfo>();
                var multiplier = ProcessNumber;
                for (var i = 0; i < ProcessNumber; i++)
                {
                    var proc = new ProcessInfo();
                    proc.Priority = i + 1;
                    proc.Quantum = BASE_QUANTUM * multiplier;
                    ProcessQueue.Enqueue(proc);
                    multiplier--;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void Run()
        {
            var process = ProcessQueue.Dequeue();
            if (process.Exited())
                return;
            
            var sw = new Stopwatch();
            sw.Start();
            process.Resume();
            while (sw.Elapsed.TotalMilliseconds < process.Quantum) {}
            sw.Stop();
            process.Suspend();
            
            if (key == ConsoleKey.UpArrow)
                RaisePriority(ref process);
            else if (key == ConsoleKey.DownArrow)
                LowerPriority(ref process);
            key = defaultKey;
            
            ProcessQueue.Enqueue(process);
        }
        
        public static void MonitorKeys()
        {
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    if (ProcessQueue.Count == 0)
                        return;
                }
                key = Console.ReadKey(true).Key;
            }
        }
        
        private static void RaisePriority(ref ProcessInfo process)
        {
            process.Priority++;
            process.Quantum = BASE_QUANTUM * process.Priority;
        }
        
        private static void LowerPriority(ref ProcessInfo process)
        {
            if (process.Priority == 1)
                return;
            process.Priority--;
            process.Quantum = BASE_QUANTUM * process.Priority;
        }
    }
}