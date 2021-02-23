﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace os_lab_1
{
    static class Drives
    {
        public static void Execute()
        {
            var drives = DriveInfo.GetDrives();

            foreach(var drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Name: {drive.Name}");
                    Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                    Console.WriteLine($"Size: {drive.TotalSize}");
                    Console.WriteLine($"Filesystem: {drive.DriveFormat}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Drive {drive.Name} is not ready.");
                    Console.WriteLine();
                }
            }
        }
    }
}


