using MusicWorld.Data.Models;
using MusicWorld.Models.Album;
using MusicWorld.Models.Song;
using System.Collections.Generic;

namespace MusicWorld.Models.Song
{
    public class SongSongsFromAlbumViewModel
    {
        public SongSongsFromAlbumViewModel()
        {

        }

        public SongSongsFromAlbumViewModel(AlbumViewModel album, List<SongViewModel> songs)
        {
            Album = album;
            Songs = songs;
        }

        public AlbumViewModel Album { get; set; }

        public List<SongViewModel> Songs { get; set; }
    }
}