namespace MusicPlaylistRandomizer
{
    public class Track
    {
        public string Title { get; }
        public string Artist { get; }

        public Track(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Artist} — {Title}";
        }
    }
}
