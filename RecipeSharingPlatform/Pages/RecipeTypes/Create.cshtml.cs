using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Pages.RecipeTypes
{
    public class CreateModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

        public CreateModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeType RecipeType { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeTypes.Add(RecipeType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
