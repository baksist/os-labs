using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace os_lab_1
{
    static class Drives
    {
        private static DriveInfo[] drives = DriveInfo.GetDrives();
        public static void Execute()
        {
            foreach(var drive in drives)
            {
                Console.WriteLine($"Name: {drive.Name}");
                Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                Console.WriteLine($"Size: {drive.TotalSize}");
                Console.WriteLine($"Filesystem: {drive.DriveFormat}");
                Console.WriteLine();
            }
        }
    }
}


