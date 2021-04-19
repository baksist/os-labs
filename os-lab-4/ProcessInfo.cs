using System.Diagnostics;

namespace os_lab_4
{
    public class ProcessInfo
    {
        private const string ModulePath = "C:\\Windows\\system32\\mspaint.exe";
       
        public int Quant;
        public int Priority;

        public Process _process;
        public bool IsReady;
        public bool IsRunning;
        public bool IsIdle;

        public ProcessInfo()
        {
            _process = new Process{StartInfo = new ProcessStartInfo(ModulePath)};
            IsReady = true;
            IsRunning = false;
            IsIdle = false;
            //_process.Start();
        }
        
    }
}