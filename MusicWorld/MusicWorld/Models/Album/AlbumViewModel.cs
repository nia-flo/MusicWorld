using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Album
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        { }

        public AlbumViewModel(string id, string name, ArtistViewModel artist, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            Artist = artist;
            ReleaseDate = releaseDate;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ArtistViewModel Artist { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
