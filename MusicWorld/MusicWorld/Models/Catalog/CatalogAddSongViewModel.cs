using MusicWorld.Models.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Catalog
{
    public class CatalogAddSongViewModel
    {
        public CatalogAddSongViewModel()
        {

        }

        public CatalogAddSongViewModel(SongViewModel song, List<CatalogViewModel> catalogs)
        {
            Song = song;
            Catalogs = catalogs;
        }

        public SongViewModel Song { get; set; }

        public List<CatalogViewModel> Catalogs { get; set; }

        public string ChoosenCatalogId { get; set; }
    }
}
