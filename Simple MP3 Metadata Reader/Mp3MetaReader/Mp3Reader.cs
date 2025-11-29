using System;
using System.IO;
using System.Text;

namespace Mp3MetaReader
{
    public static class Mp3Reader
    {
        public static Mp3Metadata Read(string path)
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            if (fs.Length < 128)
                throw new Exception("File is too small to contain ID3v1 tag.");

            fs.Seek(-128, SeekOrigin.End);

            byte[] buffer = new byte[128];
            fs.Read(buffer, 0, 128);

            if (Encoding.ASCII.GetString(buffer, 0, 3) != "TAG")
                throw new Exception("No ID3v1 tag found.");

            return new Mp3Metadata
            {
                Title = Clean(buffer, 3, 30),
                Artist = Clean(buffer, 33, 30),
                Album = Clean(buffer, 63, 30),
                Year = Clean(buffer, 93, 4),
                Genre = buffer[127].ToString()
            };
        }

        private static string Clean(byte[] data, int start, int length)
        {
            return Encoding.ASCII.GetString(data, start, length).Trim('\0', ' ');
        }
    }
}
