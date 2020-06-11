using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Artist
{
    public class ArtistEditViewModel : ArtistCreateViewModel
    {
        public ArtistEditViewModel()
        { }

        public ArtistEditViewModel(string id, string name, IFormFile photo, string description)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Description = description;
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }

        public string Description { get; set; }
    }
}
