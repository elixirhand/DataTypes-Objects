using System;
using System.IO;
using System.Text;
using Xunit;

namespace ClassLibrary.Tests
{
    public class FileProcessorForZipTests
    {
        #region Path

        [Fact]
        public void GetInputFilePath()
        {
            FileProcessor sut = new FileProcessor();

            string path = sut.GetInputFilePath();

            Assert.Equal(@"C:\temp\pspath\test.txt", path);
        }

        [Fact]
        public void UsefulPathMethods()
        {
            string path = @"c:\temp\pspath\test.txt";

            path = Path.ChangeExtension(path, "bak");

            string dirName = Path.GetDirectoryName(path);

            string ext = Path.GetExtension(path);

            string file = Path.GetFileName(path);

            string fileNoExt = Path.GetFileNameWithoutExtension(path);

            bool hasExt = Path.HasExtension(path);
        }

        [Fact]
        public void UsefulGeneralMethods()
        {
            char[] invalidNameChars = Path.GetInvalidFileNameChars();

            string rndFileName = Path.GetRandomFileName();

            string rndTempFile = Path.GetTempFileName();

            string userTempPath = Path.GetTempPath();

            char platformSpecificDirSeparater = Path.DirectorySeparatorChar;
        }

        [Fact]
        public void PathCombinePeculiarities()
        {
            string result = Path.Combine(@"\data", @"c:\temp");

            result = Path.Combine(@"c:\temp", @"\data");

            result = Path.Combine(@"c:\temp", @"data");

            result = Path.Combine(@"c:\temp", 
                                  @"\data".TrimStart(Path.DirectorySeparatorChar));


            // using ".." to refer to parent dir
            result = Path.Combine(@"c:\temp\data", @"..");

            result = Path.GetFullPath(result);                        
        }

        #endregion


        #region Uri

        [Fact]
        public void GetUploadUri()
        {
            FileProcessor sut = new FileProcessor();

            string uri = sut.GetUploadUri();

            //Assert.Equal("https://elixirhand.com/", uri);
            Assert.Equal("http://elixirhand.com/opinion", uri);
        }
        
        [Fact]
        public void NonHttpUris()
        {
            Uri localFile = new Uri(@"c:\temp\somefile.bin");
            Uri uncLanFile = new Uri(@"\\somepc\shareddocs\somefile.txt");
        }
        
        [Fact]
        public void CreatingRelativeAndAbsolute()
        {
            Uri dct1 = new Uri("http://elixirhand.com"); // assumes absolute
            Uri dct2 = new Uri("http://elixirhand.com", UriKind.Absolute);

            Uri relativeUri = new Uri("/index.html", UriKind.Relative);

            Uri relativeOrAbsolute = new Uri("/blog/", UriKind.RelativeOrAbsolute);

            Uri baseUri = new Uri("http://elixirhand.com");
            Uri fullUri = new Uri(baseUri, relativeUri);
        }

        [Fact]
        public void UriParts()
        {
            Uri dct = new Uri("http://elixirhand.com:8080/blog/?tag=code#somefragment");

            string scheme = dct.Scheme;

            string authority = dct.Authority; // Host name + port number (if non default port)
            string authorityHost = dct.Host; // Domain name or IP address (no port)
            int port = dct.Port;

            string pathAndQuery = dct.PathAndQuery;
            string absolutePath = dct.AbsolutePath;
            string query = dct.Query;

            string fragment = dct.Fragment;
        }


        [Fact]
        public void ModifyingAUri()
        {
            Uri dct = new Uri("http://elixirhand.com:8080/blog/?tag=code#somefragment");

            // dct.Fragment = "newfrag"; // read only
            // dct.Port = 9090; // read only

            UriBuilder builder = new UriBuilder(dct);
            builder.Port = 9090;
            builder.Fragment = "newfrag";

            Uri modifiedDct = builder.Uri;
            string modified = modifiedDct.ToString();
        }


        [Fact]
        public void SomeOtherUsefulThings()
        {
            Uri dct = new Uri("http://elixirhand.com/blog/");
            bool isDefaultPort = dct.IsDefaultPort;
            bool isFile = dct.IsFile;
            bool isUnc = dct.IsUnc;

            Uri localFile = new Uri("file:///c:/temp/somefile.bin");
            string path = localFile.LocalPath;
            isFile = localFile.IsFile;
            isUnc = localFile.IsUnc;
        }

        #endregion


        #region zip files

        private const string inputDirectory = @"c:\psdata\somefiles";
        private const string outputZipFile = @"c:\psdata\somefiles1.zip";

        [Fact]
        public void ZipFiles()
        {
            File.Delete(outputZipFile);

            FileProcessor sut = new FileProcessor();

            sut.ZipDirectory(inputDirectory, outputZipFile);

            Assert.True(File.Exists(outputZipFile));
        }

        [Fact]
        public void UnzipFiles()
        {
            ZipFiles();

            string unzipDestinationDir = Path.Combine(inputDirectory, @"..\unzip");
            unzipDestinationDir = Path.GetFullPath(unzipDestinationDir);

            if (Directory.Exists(unzipDestinationDir))
            {
                Directory.Delete(unzipDestinationDir, true);
            }

            FileProcessor sut = new FileProcessor();

            sut.UnZip(outputZipFile, unzipDestinationDir);

            // Asserts omitted
        }

        [Fact]
        public void AddFile()
        {
            ZipFiles();

            FileProcessor sut = new FileProcessor();

            sut.AddToZip(outputZipFile, @"c:\psdata\AnExtraFile.txt");

            // Asserts omitted
        }

        [Fact]
        public void RemoveFile()
        {
            ZipFiles();

            FileProcessor sut = new FileProcessor();

            sut.RemoveFromZip(outputZipFile, @"somefiles\text1.txt");

            // Asserts omitted
        }

        #endregion
    }
}
