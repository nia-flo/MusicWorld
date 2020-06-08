using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Data.Models
{
    public class Artist
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public string Description { get; set; }

    }
}
