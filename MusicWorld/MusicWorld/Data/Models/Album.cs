using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Data.Models
{
    public class Album
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual Artist Artist { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
