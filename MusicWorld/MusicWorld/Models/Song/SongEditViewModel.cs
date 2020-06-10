using MusicWorld.Models.Album;
using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Song
{
    public class SongEditViewModel
    {
        public SongEditViewModel()
        { }

        public SongEditViewModel(string id, string name, DateTime duration, List<AlbumViewModel> allAlbums,
            AlbumViewModel choosenAlbum, List<ArtistViewModel> allArtists, ArtistViewModel choosenArtist)
        {
            Id = id;
            Name = name;
            Duration = duration;
            AllAlbums = allAlbums;
            ChoosenAlbum = choosenAlbum;
            AllArtists = allArtists;
            ChoosenArtist = choosenArtist;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Duration { get; set; }

        public virtual List<AlbumViewModel> AllAlbums { get; set; }

        public AlbumViewModel ChoosenAlbum { get; set; }

        public virtual List<ArtistViewModel> AllArtists { get; set; }

        public ArtistViewModel ChoosenArtist { get; set; }
    }
}
