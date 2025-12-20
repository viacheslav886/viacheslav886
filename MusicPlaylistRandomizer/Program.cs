using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistRandomizer
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Music Playlist Randomizer");
            Console.WriteLine("--------------------------");

            Console.Write("Enter path to playlist file (or press Enter to skip): ");
            string path = Console.ReadLine()!;

            var playlist = new Playlist();
            var tracks = new List<Track>();

            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    var parts = line.Split(" - ");
                    if (parts.Length == 2)
                        tracks.Add(new Track(parts[1], parts[0]));
                }
            }
            else
            {
                Console.WriteLine("\nEnter tracks manually (Artist - Title). Empty line to finish:");

                while (true)
                {
                    string line = Console.ReadLine()!;
                    if (string.IsNullOrWhiteSpace(line)) break;

                    var parts = line.Split(" - ");
                    if (parts.Length == 2)
                        tracks.Add(new Track(parts[1], parts[0]));
                }
            }

            playlist.AddRange(tracks);

            Console.WriteLine("\nYour randomized playlist:\n");

            foreach (var t in playlist.Randomize())
                Console.WriteLine(t);
        }
    }
}
