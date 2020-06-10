using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicWorld.Data;
using MusicWorld.Data.Models;
using MusicWorld.Models.Album;
using MusicWorld.Models.Artist;
using MusicWorld.Models.Song;

namespace MusicWorld.Controllers
{
    public class SongController : Controller
    {
        private readonly MusicWorldDbContext _context;
        public SongController(MusicWorldDbContext context)
        {
            _context = context;
        }
        public IActionResult Songs()
        {
            List<SongViewModel> songs = _context.Songs.Select(s => new SongViewModel(s.Id, s.Name, s.Duration,
                new AlbumViewModel(s.Album.Id, s.Album.Name, new ArtistViewModel(s.Album.Artist.Id, s.Album.Artist.Name,
                    s.Album.Artist.Photo, s.Album.Artist.Description), s.Album.ReleaseDate),
                new ArtistViewModel(s.Artist.Id, s.Artist.Name, s.Artist.Photo, s.Artist.Description)))
                .ToList();

            return View(songs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<ArtistViewModel> artists = _context.Artists.Select(a => new ArtistViewModel(a.Id, a.Name, a.Photo, a.Description)).ToList();

            List<AlbumViewModel> albums = _context.Albums.Select(a => new AlbumViewModel(a.Id, a.Name,
                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate)).ToList();

            SongCreateViewModel model = new SongCreateViewModel(albums, artists);

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SongCreateViewModel model)
        {
            Artist artist = _context.Artists.FirstOrDefault(a => a.Id == model.ChoosenArtistId);
            Album album = _context.Albums.FirstOrDefault(a => a.Id == model.ChoosenAlbumId);

            Song song = new Song
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Duration = model.Duration,
                Artist = artist,
                Album = album
            };

            _context.Songs.Add(song);
            _context.SaveChanges();

            return Redirect("~/Song/Songs");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Song song = _context.Songs.FirstOrDefault(s => s.Id == id);

            List<ArtistViewModel> allArtists = _context.Artists.Select(a => new ArtistViewModel(a.Id, a.Name, a.Photo, a.Description)).ToList();

            ArtistViewModel choosenArtist = new ArtistViewModel(song.Artist.Id, song.Artist.Name, song.Artist.Photo, song.Artist.Description);

            List<AlbumViewModel> allAlbums = _context.Albums.Select(a => new AlbumViewModel(a.Id, a.Name,
                new ArtistViewModel(a.Artist.Id, a.Artist.Name, a.Artist.Photo, a.Artist.Description), a.ReleaseDate)).ToList();

            AlbumViewModel choosenAlbum = new AlbumViewModel(song.Album.Id, song.Album.Name, choosenArtist, song.Album.ReleaseDate);

            SongEditViewModel model = new SongEditViewModel(song.Id, song.Name, song.Duration, allAlbums, choosenAlbum,
                allArtists, choosenArtist);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SongEditViewModel model)
        {
            Song song = _context.Songs.FirstOrDefault(s => s.Id == model.Id);
            Artist artist = _context.Artists.FirstOrDefault(a => a.Id == model.ChoosenArtist.Id);
            Album album = _context.Albums.FirstOrDefault(a => a.Id == model.ChoosenAlbum.Id);

            song.Duration = model.Duration;
            song.Artist = artist;
            song.Album = album;

            _context.Update(song);
            _context.SaveChanges();

            return Redirect("~/Song/Songs");
        }
        public IActionResult Delete(string id)
        {
            Song song = _context.Songs.FirstOrDefault(s => s.Id == id);

            _context.Songs.Remove(song);
            _context.SaveChanges();

            return Redirect("~/Song/Songs");
        }
    }
}
