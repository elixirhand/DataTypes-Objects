using System;
using System.IO;
using System.IO.Compression;

namespace ClassLibrary
{
    public class FileProcessor
    {
        public void Process()
        {
            string inputFilePath = GetInputFilePath();

            // Perform some file processing

            string uploadUri = GetUploadUri();

            // upload file
        }

        public string GetInputFilePath()
        {
            var drive = @"C:\";
            var dir = @"temp\pspath\";
            var file = "test.txt";




            return Path.Combine(drive, dir, file);
        }

        public string GetUploadUri()
        {
            //Uri uploadUri = new Uri("https://elixirhand.com");
            Uri uploadUri = new Uri("http://elixirhand.com/opinion");

            return uploadUri.ToString();
        }


        public void ZipDirectory(string dirToZip, string outputZipFilePath)
        {
            ZipFile.CreateFromDirectory(dirToZip,
                                        outputZipFilePath,
                                        CompressionLevel.Fastest,
                                        true);
        }

        public void UnZip(string zipFilePath, string outputDir)
        {
            ZipFile.ExtractToDirectory(zipFilePath, outputDir);
        }
    }
}
