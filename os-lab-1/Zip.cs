using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace os_lab_1
{
    static class Zip
    {
        public static void Execute()
        {
            var FilePath = Directory.GetCurrentDirectory() + "\\new-file.txt";
            var ArchivePath = Directory.GetCurrentDirectory() + "\\new-file.zip";
            var DecompPath = FilePath.Replace("new-file.txt", "new-file-dcmp.txt");
            Compress(FilePath, ArchivePath);

            Decompress(ArchivePath, DecompPath);

            Console.WriteLine($"Source file size: {new FileInfo(FilePath).Length}\n Archive size: {new FileInfo(ArchivePath).Length}\n Decompressed file size: {new FileInfo(DecompPath).Length}");

            File.Delete(ArchivePath);
            File.Delete(DecompPath);
        }
        
        private static void Compress(string sourcePath, string targetPath)
        {
            using (FileStream src = new FileStream(sourcePath, FileMode.OpenOrCreate))
            {
                using (FileStream target = File.Create(targetPath))
                {
                    using (GZipStream compress = new GZipStream(target, CompressionMode.Compress))
                    {
                        src.CopyTo(compress);
                    }
                }
            }
        }

        private static void Decompress(string sourcePath, string targetPath)
        {
            using (FileStream src = new FileStream(sourcePath, FileMode.OpenOrCreate))
            {
                using (FileStream target = File.Create(targetPath))
                {
                    using (GZipStream decompress = new GZipStream(src, CompressionMode.Decompress))
                    {
                        decompress.CopyTo(target);
                    }
                }
            }
        }
    }
}
