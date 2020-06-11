using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Song
{
    public class SongSearchViewModel
    {
        public SongSearchViewModel()
        {

        }

        public SongSearchViewModel(List<SongViewModel> songs)
        {
            Songs = songs;
        }

        public string NameToSearch { get; set; }

        public List<SongViewModel> Songs { get; set; }
    }
}
