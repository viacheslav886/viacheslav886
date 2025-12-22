using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlaylistRandomizer
{
    public class Playlist
    {
        private readonly List<Track> _tracks = new();

        public void Add(Track track) => _tracks.Add(track);

        public void AddRange(IEnumerable<Track> tracks) => _tracks.AddRange(tracks);

        public IEnumerable<Track> Randomize()
        {
            return _tracks.OrderBy(_ => Guid.NewGuid());
        }
    }
}
