namespace os_lab_4
{
    // TODO: define when the process is "ready"
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