using MusicWorld.Models.Album;
using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Song
{
    public class SongCreateViewModel
    {
        public SongCreateViewModel()
        { }

        public SongCreateViewModel(List<AlbumViewModel> allAlbums, List<ArtistViewModel> allArtists)
        {
            AllAlbums = allAlbums;
            AllArtists = allArtists;
        }

        public string Name { get; set; }

        public DateTime Duration { get; set; }

        public virtual List<AlbumViewModel> AllAlbums { get; set; }

        public string ChoosenAlbumId { get; set; }

        public virtual List<ArtistViewModel> AllArtists { get; set; }

        public string ChoosenArtistId { get; set; }
    }
}
