using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.Artist
{
    public class ArtistCreateViewModel
    {
        public ArtistCreateViewModel()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }

        public string Description { get; set; }
    }
}
