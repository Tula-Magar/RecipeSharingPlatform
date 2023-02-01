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
    public class DetailsModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

        public DetailsModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
