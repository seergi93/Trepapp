using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trepapp.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }
        public string RoleId { get; set; }
    }
}
