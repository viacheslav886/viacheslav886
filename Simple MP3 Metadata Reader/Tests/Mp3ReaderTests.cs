using NUnit.Framework;
using Mp3MetaReader;
using System.IO;

namespace Tests
{
    public class Mp3ReaderTests
    {
        [Test]
        public void ShouldThrowIfNoTag()
        {
            string tmp = Path.GetTempFileName();
            File.WriteAllBytes(tmp, new byte[200]);
            Assert.Throws<Exception>(() => Mp3Reader.Read(tmp));
        }

        [Test]
        public void ShouldReadTagCorrectly()
        {
            // Create fake MP3 tag
            byte[] tag = new byte[128];
            File.WriteAllBytes("test.mp3", tag);

            tag[0] = (byte)'T';
            tag[1] = (byte)'A';
            tag[2] = (byte)'G';

            Encoding.ASCII.GetBytes("SongTitle".PadRight(30)).CopyTo(tag, 3);

            File.WriteAllBytes("test.mp3", tag);

            var meta = Mp3Reader.Read("test.mp3");
            Assert.AreEqual("SongTitle", meta.Title);
        }
    }
}
