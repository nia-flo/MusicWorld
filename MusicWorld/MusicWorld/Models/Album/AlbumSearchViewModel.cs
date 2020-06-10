using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Album
{
    public class AlbumSearchViewModel
    {
        public AlbumSearchViewModel()
        {

        }

        public AlbumSearchViewModel(List<AlbumViewModel> albums)
        {
            Albums = albums;
        }

        [Display(Name = "Seach album")]
        public string NameToSearch { get; set; }

        public List<AlbumViewModel> Albums { get; set; }
    }
}
