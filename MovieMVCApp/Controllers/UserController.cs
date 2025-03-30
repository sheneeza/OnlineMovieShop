using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MovieMVCApp.Models;
using Infrastructure.Data;
using ApplicationCore.Entities;
using MovieMVCApp.Helpers;

namespace MovieMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly MovieDbContext _context;

        public UserController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Find the user by email
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // Hash the input password with the stored salt
            var hashedInput = PasswordHelper.HashPassword(model.Password, user.Salt);

            // Compare with stored hashed password
            if (hashedInput != user.HashedPassword)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // Auth success – build claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if email is already used
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(model);
            }

            // Hash password
            var salt = PasswordHelper.GenerateSalt();
            var hashedPassword = PasswordHelper.HashPassword(model.Password, salt);

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth ?? DateTime.MinValue,
                Email = model.Email,
                HashedPassword = hashedPassword,
                Salt = salt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Auto-login after register
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }
    }
}
