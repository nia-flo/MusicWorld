using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Artist
{
    public class ArtistSearchViewModel
    {
        public ArtistSearchViewModel()
        {

        }

        public ArtistSearchViewModel(List<ArtistViewModel> artists)
        {
            Artists = artists;
        }

        [Display(Name = "Seach artist")]
        public string NameToSearch { get; set; }

        public List<ArtistViewModel> Artists { get; set; }
    }
}
