using System;

namespace Mp3MetaReader
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter MP3 file path: ");
            string path = Console.ReadLine() ?? "";

            try
            {
                var meta = Mp3Reader.Read(path);

                Console.WriteLine("\n--- METADATA ---");
                Console.WriteLine($"Title:  {meta.Title}");
                Console.WriteLine($"Artist: {meta.Artist}");
                Console.WriteLine($"Album:  {meta.Album}");
                Console.WriteLine($"Year:   {meta.Year}");
                Console.WriteLine($"Genre:  {meta.Genre}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
