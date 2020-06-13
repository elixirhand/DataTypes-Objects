using System;
using System.IO;

namespace FilesPathsURIs
{
    class Program
    {
        static void Main(string[] args)
        {
           
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

    }
}
