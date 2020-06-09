using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicWorld.Data;
using MusicWorld.Data.Models;
using MusicWorld.Models.User;

namespace MusicWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly MusicWorldDbContext _context;
        public UserController(MusicWorldDbContext context)
        {
            _context = context;
        }
        public IActionResult Users()
        {
            List<UserViewModel> users = _context.Users.Select(u => new UserViewModel(u.UserName, u.FirstName, u.LastName, u.Id)).ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);

            UserEditViewModel model = new UserEditViewModel(user.UserName, user.FirstName, user.LastName, user.Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel model)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == model.Id);

            if(_context.Users.FirstOrDefault(u => u.UserName == model.Username && u.Id != model.Id) != null)
            {
                ModelState.AddModelError("Username", "There is an user with this username.");
            }

            if (ModelState.IsValid)
            {
                user.UserName = model.Username;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                _context.Update(user);
                _context.SaveChanges();

                return Redirect("~/User/Users/");
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Redirect("~/User/Users/");
        }
    }
}
