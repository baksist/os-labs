using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace os_lab_4
{
    // TODO: suspend/resume process, catch interruptions and priority change signals
    public static class Scheduler
    {
        private const int ProcessNumber = 2;
        public static Queue<ProcessInfo> ProcessQueue;
        private const int BASE_QUANTUM = 1000;
        //private static ProcessInfo suspendedProcess = null;

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
            while (sw.Elapsed.TotalMilliseconds < process.Quantum)
                WaitForInterruption();
            sw.Stop();
            process.Suspend();
            ProcessQueue.Enqueue(process);
        }

        public static void RaisePriority(int i)
        {
            if (i == 1)
            {
                Console.WriteLine("process has the highest priority already :(");
                return;
            }

            ref var proc = ref ProcessQueue.ToArray()[i - 1];
            proc.Priority++;
            proc.Quantum = BASE_QUANTUM * proc.Priority;

            proc = ref ProcessQueue.ToArray()[i - 2];
            proc.Priority--;
            proc.Quantum = BASE_QUANTUM * proc.Priority;
        }

        public static void LowerPriority(int i)
        {
            if (i == ProcessNumber)
            {
                Console.WriteLine("process has the lowest priority already :(");
                return;
            }
            
            ref var proc = ref ProcessQueue.ToArray()[i - 1];
            proc.Priority--;
            proc.Quantum = BASE_QUANTUM * proc.Priority;
            
            proc = ref ProcessQueue.ToArray()[i];
            proc.Priority++;
            proc.Quantum = BASE_QUANTUM * proc.Priority;
        }

        public static void WaitForInterruption()
        {
        }

    }
}