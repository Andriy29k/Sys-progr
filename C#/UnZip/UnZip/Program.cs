using System;
using System.IO;
using System.IO.Compression;

public class UnzipUtility
{
    public static void Unzip(string zipFilePath, string destDirectory)
    {
        if (!Directory.Exists(destDirectory))
        {
            Directory.CreateDirectory(destDirectory);
        }

        using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string filePath = Path.Combine(destDirectory, entry.FullName);

                if (entry.Name == "")
                {
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    entry.ExtractToFile(filePath, true);
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        string zipFilePath = "D:\\Archive.zip";
        string destDirectory = "D:\\UnZipToHere\\";
        try
        {
            Unzip(zipFilePath, destDirectory);
            Console.WriteLine("Unzipping completed successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while unzipping the file.");
            Console.WriteLine(e.Message);
        }
    }
}
