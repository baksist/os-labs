using System;
using System.Collections.Generic;
using System.Threading;

namespace os_lab_4
{
    // TODO: suspend/resume process, catch interruptions and priority change signals
    public static class Scheduler
    {
        private const int ProcessNumber = 5;
        public static Queue<ProcessInfo> ProcessQueue;
        private const int BASE_QUANT = 1000;
        private static ProcessInfo suspendedProcess = null;

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
                    proc.Quant = BASE_QUANT * multiplier;
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
            var proc = ProcessQueue.Dequeue();
            Thread.Sleep(proc.Quant);
            Console.WriteLine($"process {proc.Priority} ran");
            ProcessQueue.Enqueue(proc);
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
            proc.Quant = BASE_QUANT * proc.Priority;

            proc = ref ProcessQueue.ToArray()[i - 2];
            proc.Priority--;
            proc.Quant = BASE_QUANT * proc.Priority;
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
            proc.Quant = BASE_QUANT * proc.Priority;
            
            proc = ref ProcessQueue.ToArray()[i];
            proc.Priority++;
            proc.Quant = BASE_QUANT * proc.Priority;
        }

        // maybe move these functions to ProcessInfo? 
        public static void SuspendProcess()
        {
        }

        public static void ResumeProcess()
        {
        }

        public static void WaitForInterruption()
        {
        }
    }
}