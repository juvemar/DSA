namespace _02.TraverseDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        private static List<string> exeFiles = new List<string>();

        public static void Main()
        {
            var windowsDirectory = @"c:\Windows";
            var subdirectories = Directory.GetDirectories(windowsDirectory);

            TraverseDirectories(subdirectories);

            exeFiles.ForEach(x => Console.WriteLine(x));
        }

        private static void TraverseDirectories(string[] directories)
        {
            try
            {
                foreach (var folder in directories)
                {
                    GetFiles(folder);
                    TraverseDirectories(Directory.GetDirectories(folder));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        private static void GetFiles(string folder)
        {
            var files = Directory.GetFiles(folder);

            foreach (var file in files)
            {
                if (file.EndsWith(".exe"))
                {
                    exeFiles.Add(Path.GetFileName(file));
                }
            }
        }
    }
}
