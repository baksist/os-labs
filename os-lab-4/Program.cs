using System.Threading;

namespace os_lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Scheduler.Initialize();
            while (true)
            {
                Scheduler.Run();
                if (Scheduler.ProcessQueue.Count == 0)
                    return;
            }
        }
    }
}