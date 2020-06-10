using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Album
{
    public class AlbumAlbumsFromArtistViewModel
    {
        public AlbumAlbumsFromArtistViewModel()
        {

        }

        public AlbumAlbumsFromArtistViewModel(ArtistViewModel artist, List<AlbumViewModel> albums)
        {
            Artist = artist;
            Albums = albums;
        }

        public ArtistViewModel Artist { get; set; }

        public List<AlbumViewModel> Albums { get; set; }
    }
}
