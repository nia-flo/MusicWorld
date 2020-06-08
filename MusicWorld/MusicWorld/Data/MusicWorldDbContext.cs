using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWorld.Data.Models;

namespace MusicWorld.Data
{
    public class MusicWorldDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public virtual DbSet<Catalog> Catalogs { get; set; }

        public virtual DbSet<Artist> Artists { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Song> Songs { get; set; }

        public MusicWorldDbContext(DbContextOptions<MusicWorldDbContext> options)
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
