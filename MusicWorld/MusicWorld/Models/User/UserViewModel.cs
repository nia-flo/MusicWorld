using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.User
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(string username, string firstName, string lastName, string id)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
