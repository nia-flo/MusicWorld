using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Data
{
    public class DbContext : IdentityDbContext<User, IdentityRole, string>
    {

        public virtual DbSet<Catalogue> Catalogs { get; set; }

        public virtual DbSet<Artist> Artists { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Song> Songs { get; set; }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

    }
}
