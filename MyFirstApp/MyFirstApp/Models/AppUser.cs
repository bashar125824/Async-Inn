using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models
{
    public class AppUser
    {
        public string UserName { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Id { get; internal set; }

        public class ApplicationUser : IdentityUser
        {
        }
    }
}
