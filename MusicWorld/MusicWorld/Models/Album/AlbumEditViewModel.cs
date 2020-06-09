using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Album
{
    public class AlbumEditViewModel : AlbumCreateViewModel
    {
        public AlbumEditViewModel()
        { }

        public AlbumEditViewModel(string id, string name, List<ArtistViewModel> allArtists, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            AllArtists = allArtists;
            ReleaseDate = releaseDate;
        }

        public string Id { get; set; }

    }
}
