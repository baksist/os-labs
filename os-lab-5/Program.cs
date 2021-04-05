using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace os_lab_5
{
    class Program
    {
        private const string ModulePath = "C:\\Windows\\system32\\mspaint.exe";
        private const int ProcessNumber = 5;
        
        static void Main(string[] args)
        {
            var ProcList = new List<ProcessInfo>();
            try
            {
                for (var i = 0; i < ProcessNumber; i++)
                {
                    ProcList.Add(new ProcessInfo(ModulePath));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}