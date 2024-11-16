using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dordea_Voicu_Lab2.Data;
using Dordea_Voicu_Lab2.Models;

namespace Dordea_Voicu_Lab2.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly Dordea_Voicu_Lab2.Data.Dordea_Voicu_Lab2Context _context;

        public CreateModel(Dordea_Voicu_Lab2.Data.Dordea_Voicu_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
