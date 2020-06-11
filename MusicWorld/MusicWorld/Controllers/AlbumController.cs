using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using MusicWorld.Data;
using MusicWorld.Data.Models;
using MusicWorld.Models.Album;
using MusicWorld.Models.Artist;

namespace MusicWorld.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MusicWorldDbContext _context;
        public AlbumController(MusicWorldDbContext context)
        {
            _context = context;
        }

        public IActionResult Albums()
        {
            List<AlbumViewModel> albums = _context.Albums.Select(a => new AlbumViewModel(a.Id, a.Name,
                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate))
                .ToList();

            return View(albums);
        }

        [HttpGet]
        public IActionResult Search()
        {
            List<AlbumViewModel> albums = _context.Albums.Select(a => new AlbumViewModel(a.Id, a.Name,
                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate))
                .ToList();

            return View(new AlbumSearchViewModel(albums));
        }

        [HttpPost]
        public IActionResult Search(AlbumSearchViewModel model)
        {
            if (model.NameToSearch.IsNullOrEmpty())
            {
                model.Albums = _context.Albums.Select(a => new AlbumViewModel(a.Id, a.Name,
                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate))
                .ToList();
            }
            else
            {
                model.Albums = _context.Albums.Where(a => a.Name.Contains(model.NameToSearch))
                                .Select(a => new AlbumViewModel(a.Id, a.Name,
                                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate)).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AlbumsFromArtist(string id)
        {
            Artist artist = _context.Artists.FirstOrDefault(a => a.Id == id);

            ArtistViewModel artistViewModel = new ArtistViewModel(artist.Id, artist.Name, artist.Photo, artist.Description);

            List<AlbumViewModel> albums = _context.Albums.Where(a => a.Artist.Id == id).Select(a => new AlbumViewModel(a.Id, a.Name,
                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate))
                .ToList();

            return View(new AlbumAlbumsFromArtistViewModel(artistViewModel, albums));
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<ArtistViewModel> artists = _context.Artists.Select(a => new ArtistViewModel(a.Id, a.Name, a.Photo, a.Description))
                .ToList();

            return View(new AlbumCreateViewModel(artists));
        }

        [HttpPost]
        public IActionResult Create(AlbumCreateViewModel model)
        {
            if (model.ChoosenArtistId.IsNullOrEmpty())
            {
                ModelState.AddModelError("ChoosenArtistId", "You must choose an artist.");
            }

            if (ModelState.IsValid)
            {
                Artist artist = _context.Artists.FirstOrDefault(a => a.Id == model.ChoosenArtistId);

                Album album = new Album
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Artist = artist,
                    ReleaseDate = model.ReleaseDate
                };

                _context.Albums.Add(album);
                _context.SaveChanges();

                return Redirect("~/Album/Albums");
            }

            model.AllArtists = _context.Artists.Select(a => new ArtistViewModel(a.Id, a.Name, a.Photo, a.Description)).ToList();

            return View(model);
        }

        public IActionResult Details(string id)
        {
            Album album = _context.Albums.FirstOrDefault(a => a.Id == id);

            AlbumViewModel model = new AlbumViewModel(album.Id, album.Name,
                new ArtistViewModel(album.Artist.Id, album.Artist.Name, album.Artist.Photo, album.Artist.Description),
                album.ReleaseDate);

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Album album = _context.Albums.FirstOrDefault(a => a.Id == id);

            List<ArtistViewModel> allArtists = _context.Artists.Select(a => new ArtistViewModel(a.Id, a.Name, a.Photo, a.Description))
                .ToList();

            AlbumEditViewModel model = new AlbumEditViewModel(album.Id, album.Name, allArtists, album.ReleaseDate);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AlbumEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Album album = _context.Albums.FirstOrDefault(a => a.Id == model.Id);
                Artist artist = _context.Artists.FirstOrDefault(a => a.Id == model.ChoosenArtistId);

                album.Name = model.Name;
                album.Artist = artist;
                album.ReleaseDate = model.ReleaseDate;

                _context.Update(album);
                _context.SaveChanges();

                return Redirect("~/Album/Albums");
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            Album album = _context.Albums.FirstOrDefault(a => a.Id == id);

            _context.Albums.Remove(album);
            _context.SaveChanges();

            return Redirect("~/Album/Albums");
        }
    }
}
