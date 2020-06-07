using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Data.Models
{
    public class Song
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Duration { get; set; }

        public virtual Album Album { get; set; }

        public virtual Artist Atrist { get; set; }
    }
}
