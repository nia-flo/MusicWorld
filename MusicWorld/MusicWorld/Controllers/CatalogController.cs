using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicWorld.Data;
using MusicWorld.Data.Models;
using MusicWorld.Models.Album;
using MusicWorld.Models.Artist;
using MusicWorld.Models.Catalog;
using MusicWorld.Models.Song;

namespace MusicWorld.Controllers
{
    public class CatalogController : Controller
    {
        private readonly MusicWorldDbContext _context;
        public CatalogController(MusicWorldDbContext context)
        {
            _context = context;
        }

        public IActionResult Catalogs()
        {
            List<CatalogViewModel> catalogs = _context.Catalogs.Select(c => new CatalogViewModel(c.Id, c.Name, c.Description)).ToList();

            return View(catalogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CatalogCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(CatalogCreateViewModel model)
        {

            Catalog catalog = new Catalog
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description
            };

            _context.Catalogs.Add(catalog);
            _context.SaveChanges();

            return Redirect("~/Catalog/Catalogs");
        }

        public IActionResult Details(string id)
        {
            Catalog catalog = _context.Catalogs.FirstOrDefault(c => c.Id == id);

            List<Song> songs = _context.SongCatalogs.Where(sc => sc.Catalog.Id == catalog.Id)
                .Select(sc => sc.Song).ToList();

            List<SongViewModel> songsViewModels = songs.Select(s => new SongViewModel(s.Id, s.Name, s.Duration,
                new AlbumViewModel(s.Album.Id, s.Album.Name, null, s.Album.ReleaseDate),
                new ArtistViewModel(s.Artist.Id, s.Artist.Name, s.Artist.Photo, s.Artist.Description))).ToList();

            CatalogDetailsViewModel model = new CatalogDetailsViewModel(catalog.Id, catalog.Name, catalog.Description, songsViewModels);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddSong(string id)
        {
            Song song = _context.Songs.FirstOrDefault(c => c.Id == id);

            SongViewModel songViewModel = new SongViewModel(song.Id, song.Name, song.Duration,
                new AlbumViewModel(song.Album.Id, song.Album.Name,
                new ArtistViewModel(song.Album.Artist.Id, song.Album.Artist.Name, song.Album.Artist.Photo, song.Album.Artist.Description),
                song.Album.ReleaseDate), new ArtistViewModel(null, song.Artist.Name, song.Artist.Photo, song.Artist.Description));

            List<CatalogViewModel> catalogs = _context.Catalogs.Select(c => new CatalogViewModel(c.Id, c.Name, c.Description)).ToList();

            CatalogAddSongViewModel model = new CatalogAddSongViewModel(songViewModel, catalogs);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddSong(CatalogAddSongViewModel model)
        {
            Song song = _context.Songs.FirstOrDefault(s => s.Id == model.Song.Id);

            Catalog catalog = _context.Catalogs.FirstOrDefault(c => c.Id == model.ChoosenCatalogId);

            SongCatalog songCatalog = new SongCatalog
            {
                Id = Guid.NewGuid().ToString(),
                Song = song,
                Catalog = catalog
            };

            _context.SongCatalogs.Add(songCatalog);
            _context.SaveChanges();

            return Redirect("~/Catalog/Details/" + catalog.Id);
        }
    }
}
