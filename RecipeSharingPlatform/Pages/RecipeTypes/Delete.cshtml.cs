using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Pages.RecipeTypes
{
    public class DeleteModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

        public DeleteModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RecipeType RecipeType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RecipeTypes == null)
            {
                return NotFound();
            }

            var recipetype = await _context.RecipeTypes.FirstOrDefaultAsync(m => m.ID == id);

            if (recipetype == null)
            {
                return NotFound();
            }
            else 
            {
                RecipeType = recipetype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RecipeTypes == null)
            {
                return NotFound();
            }
            var recipetype = await _context.RecipeTypes.FindAsync(id);

            if (recipetype != null)
            {
                RecipeType = recipetype;
                _context.RecipeTypes.Remove(RecipeType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
