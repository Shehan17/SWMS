using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWMS.Data;
using SWMS.Models;
using System.ComponentModel.DataAnnotations;

namespace SWMS.Pages
{
    public class SubmitModel : PageModel
    {

        private readonly AppDbContext _context;

        public SubmitModel(AppDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        [Required]
        public string location { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        public string wasteType { get; set; } = string.Empty;

        [BindProperty]
        public string description { get; set; } = string.Empty;


        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var report = new Report
            {

            };
             

            return RedirectToPage();

        }



    }
}
