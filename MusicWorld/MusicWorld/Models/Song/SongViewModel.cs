using MusicWorld.Models.Album;
using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Song
{
    public class SongViewModel
    {
        public SongViewModel()
        { }

        public SongViewModel(string id, string name, DateTime duration, AlbumViewModel album, ArtistViewModel artist)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Album = album;
            Artist = artist;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Duration { get; set; }

        public virtual AlbumViewModel Album { get; set; }

        public virtual ArtistViewModel Artist { get; set; }
    }
}
