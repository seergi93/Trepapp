using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trepapp.Models
{
    public class UserRole
    {
        public List<SelectListItem> userRoles;

        public UserRole()
        {
            userRoles = new List<SelectListItem>();
        }

        public async Task<List<SelectListItem>> GetRole(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, string ID)
        {
            userRoles = new List<SelectListItem>();
            string rol;
            var user = await userManager.FindByIdAsync(ID);
            var roles = await userManager.GetRolesAsync(user);
            //Si no tiene rol
            if (roles.Count == 0)
            {
                userRoles.Add(new SelectListItem()
                {
                    Value = "null",
                    Text = "No Role"
                });
            }//Si tiene rol
            else
            {
                rol = Convert.ToString(roles[0]);
                var rolesId = roleManager.Roles.Where(m => m.Name == rol);
                foreach (var data in rolesId)
                {
                    userRoles.Add(new SelectListItem()
                    {
                        Value = data.Id,
                        Text = data.Name
                    });
                }
            }
            return userRoles;
        }
    }
}
