using System;
using System.IO;

namespace FilesPathsURIs
{
    class Program
    {
        static void Main(string[] args)
        {
            FindUsefulPath();
        }

        public string GetInputFilePathShort()
        {
            var drive = @"C:\";
            var dir = @"temp\pspath\";
            var file = "test.txt";

            string fullPath = Path.Combine(drive, dir, file);
            return fullPath;
        }

        public string GetInputFilePathLong()
        {
            var drive = @"C:\";
            var dir = @"temp\pspath\";
            var file = "test.txt";

            var fullPath = drive;

            fullPath += dir;

            if (!dir.EndsWith(@"\"))
            {
                fullPath += @"\";
            }

            fullPath += file;

                return fullPath;
        }

        public static void FindUsefulPath()
        {
            string path = @"C:\temp\pspath\test.txt";
            path = Path.ChangeExtension(path, "bak");

            string dirName = Path.GetDirectoryName(path);
            Console.WriteLine(path);

            Console.WriteLine();

            Console.WriteLine(dirName);
            Console.WriteLine();

            string ext = Path.GetExtension(path);

            Console.WriteLine(ext);
            Console.WriteLine();

            string fileN = Path.GetFileName(path);
            Console.WriteLine(fileN);

            Console.WriteLine();

            string fileNE = Path.GetFileNameWithoutExtension(path);
            Console.WriteLine($"File Name wwithout extension: {fileNE}");

            Console.WriteLine();

            bool hasExtension = Path.HasExtension(path);

            Console.WriteLine($"File Has Extension Or Not: {hasExtension}");

        }
   

    }
}
