using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Album
{
    public class AlbumCreateViewModel
    {
        public AlbumCreateViewModel()
        { }

        public AlbumCreateViewModel(List<ArtistViewModel> allArtists)
        {
            AllArtists = allArtists;
            ReleaseDate = DateTime.Now;
        }

        [Required]
        public string Name { get; set; }

        public virtual List<ArtistViewModel> AllArtists { get; set; }

        public virtual string ChoosenArtistId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
