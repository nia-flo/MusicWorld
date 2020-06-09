using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Artist
{
    public class ArtistEditViewModel : ArtistViewModel
    {
        public ArtistEditViewModel()
        { }

        public ArtistEditViewModel(string id, string name, byte[] photo, string description) 
            : base(id, name, photo, description)
        {
        }
    }
}
