using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Artist
{
    public class ArtistViewModel
    {
        public ArtistViewModel() { }

        public ArtistViewModel(string id, string name, byte[] photo, string description)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Description = description;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public string Description { get; set; }
    }
}
