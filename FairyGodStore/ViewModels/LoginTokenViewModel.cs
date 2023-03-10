using FairyGodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.ViewModels
{
    public class LoginTokenViewModel
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public ICollection<Role> Roles { get; set; }
        public string Token { get; set; }

        public LoginTokenViewModel() { }
        public LoginTokenViewModel(User user, string token)
        {
            this.Email = user.Email;
            this.Fullname = user.FullName;
            this.Roles = user.Roles;
            this.Token = token;
        }
    }
}
