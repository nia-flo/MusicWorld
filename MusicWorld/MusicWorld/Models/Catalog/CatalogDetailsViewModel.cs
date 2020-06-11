using MusicWorld.Models.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Catalog
{
    public class CatalogDetailsViewModel : CatalogViewModel
    {
        public CatalogDetailsViewModel()
        {
        }

        public CatalogDetailsViewModel(string id, string name, string description, List<SongViewModel> songs) 
            : base(id, name, description)
        {
            Songs = songs;
        }

        public List<SongViewModel> Songs { get; set; }
    }
}
