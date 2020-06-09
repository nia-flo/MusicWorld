using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWorld.Models.User
{
    public class UserEditViewModel : UserViewModel
    {
        public UserEditViewModel() { }

        public UserEditViewModel(string username, string firstName, string lastName, string id)
            : base(username, firstName, lastName, id)
        { }
    }
}
