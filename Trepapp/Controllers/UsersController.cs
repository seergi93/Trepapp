using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trepapp.Data;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }
        //Obtener usuarios por ID
        public async Task<List<User>> GetUser(string id)
        {
            List<User> users = new List<User>();
            var appUsuario = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            users.Add(appUsuario);
            return users;
        }

        public async Task<string> EditUser(string id, string userName, string email,
            string phoneNumber, int accessFailedCount, string concurrencyStamp,
          bool emailConfirmed, bool lockoutEnabled, DateTimeOffset lockoutEnd, string normalizedEmail,
          string normalizedUserName, string passwordHash, bool phoneNumberConfirmed, string securityStamp,
          bool twoFactorEnabled, User user)
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
                resp = "Save";
            }
            catch (System.Exception)
            {
                resp = "Not Save";
                throw;
            }
            return resp;
        }
    }
}
