using Microsoft.AspNetCore.Mvc;
using MusicWorld.Data;
using MusicWorld.Data.Models;
using MusicWorld.Models.Artist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace MusicWorld.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MusicWorldDbContext _context;
        public ArtistController(MusicWorldDbContext context)
        {
            _context = context;
        }
        public IActionResult Artists()
        {
            List<ArtistViewModel> artists = _context.Artists.Select(a => new ArtistViewModel(a.Id, a.Name, a.Photo, a.Description)).ToList();

            return View(artists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ArtistCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(ArtistCreateViewModel model)
        {
            byte[] photo = null;
            //using (var fs1 = model.Photo.OpenReadStream())
            //using (var ms1 = new MemoryStream())
            //{
            //    fs1.CopyTo(ms1);
            //    photo = ms1.ToArray();
            //}

            Artist artist = new Artist
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Photo = photo,
                Description = model.Description
            };

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return Redirect("~/Artist/Artists");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Artist artist = _context.Artists.FirstOrDefault(a => a.Id == id);

            ArtistEditViewModel model = new ArtistEditViewModel(artist.Id, artist.Name, artist.Photo, artist.Description);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ArtistEditViewModel model)
        {
            if (_context.Artists.FirstOrDefault(a => a.Name == model.Name && a.Id != model.Id) != null)
            {
                ModelState.AddModelError("Name", "There is an user with this name.");
            }

            if (ModelState.IsValid)
            {
                Artist artist = _context.Artists.FirstOrDefault(a => a.Id == model.Id);

                artist.Name = model.Name;
                artist.Photo = model.Photo;
                artist.Description = model.Description;

                _context.Update(artist);
                _context.SaveChanges();

                return Redirect("~/Artist/Artists");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            Artist artist = _context.Artists.FirstOrDefault(a => a.Id == id);

            _context.Artists.Remove(artist);
            _context.SaveChanges();

            return Redirect("~/Artist/Artists");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            Artist artist = _context.Artists.FirstOrDefault(a => a.Id == id);

            ArtistViewModel model = new ArtistViewModel(artist.Id, artist.Name, artist.Photo, artist.Description);

            return View(model);
        }
    }
}
