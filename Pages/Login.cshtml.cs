using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWMS.Data;
using SWMS.Models;
using System.Security.Cryptography;
using System.Text;

namespace SWMS.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterInput Register { get; set; } = new();

        [BindProperty]
        public LoginInput Login { get; set; } = new();

        public string? RegisterError { get; set; }
        public string? LoginError { get; set; }

        // ---------- REGISTER ----------
        public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            bool emailExists = await _context.UserAccounts
                .AnyAsync(u => u.Email == Register.Email);

            if (emailExists)
            {
                RegisterError = "Email already registered";
                return Page();
            }

            var user = new UserAccount
            {
                Email = Register.Email,
                UserName = Register.UserName,
                PasswordHash = HashPassword(Register.Password)
            };

            _context.UserAccounts.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        // ---------- LOGIN ----------
        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string hashed = HashPassword(Login.Password);

            var user = await _context.UserAccounts.FirstOrDefaultAsync(u =>
                u.Email == Login.Email && u.PasswordHash == hashed);

            if (user == null)
            {
                LoginError = "Invalid email or password";
                return Page();
            }

            return RedirectToPage("/Index");
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(password))
            );
        }
    }

    public class RegisterInput
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string UserName { get; set; } = "";
    }

    public class LoginInput
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
