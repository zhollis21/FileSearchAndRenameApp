
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {

        Console.Write("Enter the path to the directory: ");

        var dirPath = Console.ReadLine();
        while (!Directory.Exists(dirPath))
        {
            Console.Write("Invalid directory, try again: ");


            dirPath = Console.ReadLine();
        }

        Console.Write("Enter the search term: ");

        var searchTerm = Console.ReadLine();
        while (string.IsNullOrEmpty(searchTerm))
        {
            Console.Write("Invalid input, try again: ");

            dirPath = Console.ReadLine();
        }

        Console.Write("Enter the what you want to replace the searched term: ");

        var replaceTerm = Console.ReadLine();
        while (string.IsNullOrEmpty(replaceTerm))
        {
            Console.Write("Invalid input, try again: ");

            dirPath = Console.ReadLine();
        }

        ProcessDirectory(dirPath, searchTerm, replaceTerm);
    }

    // Process all files in the directory passed in, recurse on any directories
    // that are found, and process the files they contain.
    public static void ProcessDirectory(string targetDirectory, string searchTerm, string replaceTerm)
    {
        // Process the list of files found in the directory.
        string[] directories = Directory.GetDirectories(targetDirectory, $"*{searchTerm}*", SearchOption.AllDirectories);
        foreach (string dirName in directories)
        {
            // The below is case sensative
            var newdirName = dirName.Replace(searchTerm, replaceTerm);

            if (newdirName == dirName)
            {
                continue; // Skips if there is no difference
            }

            Directory.Move(dirName, newdirName);
            Console.WriteLine($"Moved {dirName}\nto    {newdirName}\n");
        }

        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory, $"*{searchTerm}*", SearchOption.AllDirectories);
        foreach (string fileName in fileEntries)
        {
            // The below is case sensative
            var newFileName = fileName.Replace(searchTerm, replaceTerm);

            if (newFileName == fileName)
            {
                continue; // Skips if there is no difference
            }

            File.Move(fileName, newFileName);
            Console.WriteLine($"Moved {fileName}\n   to {newFileName}\n");
        }
    }
}
