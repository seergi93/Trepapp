using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trepapp.Data;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private UserRole _userRole;
        public List<SelectListItem> userRole;

        public UsersController(ApplicationDbContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRole = new UserRole();
            userRole = new List<SelectListItem>();
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var ID = "";
            List<User> user = new List<User>();
            var appUser = await _context.User.ToListAsync();
            foreach (var data in appUser)
            {
                ID = data.Id;
                userRole = await _userRole.GetRole(_userManager, _roleManager, ID);
                user.Add(new User()
                {
                    Id = data.Id,
                    UserName = data.UserName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    Role = userRole[0].Text
                });
            }
            return View(user.ToList());
            // return View(await _context.User.ToListAsync());
        }
        //Obtener usuarios por ID
        public async Task<List<User>> GetUser(string id)
        {
            List<User> users = new List<User>();
            var appUsuario = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            userRole = await _userRole.GetRole(_userManager, _roleManager, id);
            users.Add(new User()
            {
                Id = appUsuario.Id,
                UserName = appUsuario.UserName,
                PhoneNumber = appUsuario.PhoneNumber,
                Email = appUsuario.Email,
                Role = userRole[0].Text,
                RoleId = userRole[0].Value,
                AccessFailedCount = appUsuario.AccessFailedCount,
                ConcurrencyStamp = appUsuario.ConcurrencyStamp,
                EmailConfirmed = appUsuario.EmailConfirmed,
                LockoutEnabled = appUsuario.LockoutEnabled,
                LockoutEnd = appUsuario.LockoutEnd,
                NormalizedEmail = appUsuario.NormalizedEmail,
                NormalizedUserName = appUsuario.NormalizedUserName,
                PasswordHash = appUsuario.PasswordHash,
                PhoneNumberConfirmed = appUsuario.PhoneNumberConfirmed,
                SecurityStamp = appUsuario.SecurityStamp,
                TwoFactorEnabled = appUsuario.TwoFactorEnabled
            });

            return users;
        }

        public async Task<List<SelectListItem>> GetRoles()
        {
            List<SelectListItem> rolesList = new List<SelectListItem>();
            rolesList = _userRole.Roles(_roleManager);

            return rolesList;

        }

        public async Task<string> EditUser(string id, string userName, string email,
            string phoneNumber, int accessFailedCount, string concurrencyStamp,
          bool emailConfirmed, bool lockoutEnabled, DateTimeOffset lockoutEnd, string normalizedEmail,
          string normalizedUserName, string passwordHash, bool phoneNumberConfirmed, string securityStamp,
          bool twoFactorEnabled, string selectRole, User user)
        {
            var resp = "";
            try
            {
                user = new User
                {
                    Id = id,
                    UserName = userName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = emailConfirmed,
                    LockoutEnabled = lockoutEnabled,
                    LockoutEnd = lockoutEnd,
                    NormalizedEmail = normalizedEmail,
                    NormalizedUserName = normalizedUserName,
                    PasswordHash = passwordHash,
                    PhoneNumberConfirmed = phoneNumberConfirmed,
                    SecurityStamp = securityStamp,
                    TwoFactorEnabled = twoFactorEnabled,
                    AccessFailedCount = accessFailedCount,
                    ConcurrencyStamp = concurrencyStamp
                };
                //Actualizar datos
                _context.Update(user);
                await _context.SaveChangesAsync();

                //Obtenemos usuario
                var usuario = await _userManager.FindByIdAsync(id);
                userRole = await _userRole.GetRole(_userManager, _roleManager, id);

                if (userRole[0].Text != "No Role")
                {
                    await _userManager.RemoveFromRoleAsync(usuario, userRole[0].Text);
                }
                if (userRole[0].Text == "No Role")
                {
                    selectRole = "User";
                }
                var result = await _userManager.AddToRoleAsync(usuario, selectRole);



                resp = "Save";
            }
            catch (Exception)
            {
                resp = "Not Save";
                throw;
            }
            return resp;
        }

        public async Task<String> DeleteUser(string id)
        {
            var response = "";

            try
            {
                var applicationUser = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
                _context.User.Remove(applicationUser);
                await _context.SaveChangesAsync();
                response = "Delete";
            }
            catch
            {
                response = "NoDelete";
            }
            return response;
        }


    }


}
