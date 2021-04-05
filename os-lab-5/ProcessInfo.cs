using System.Diagnostics;

namespace os_lab_5
{
    public class ProcessInfo
    {
        public Process _process;
        private int quant;
        public bool IsReady { get; set; }
        public bool IsRunning { get; set; }
        public bool IsIdle { get; set; }

        public ProcessInfo(string path)
        {
            _process = new Process{StartInfo = new ProcessStartInfo(path)};
            IsReady = true;
            IsRunning = false;
            IsIdle = false;
            _process.Start();
        }
    }
}