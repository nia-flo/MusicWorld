using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Data.Models
{
    public class SongCatalog
    {
        public string Id { get; set; }

        public virtual Song Song { get; set; }

        public virtual Catalog Catalog { get; set; }
    }
}
