using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

        public DetailsModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }
           
            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeType)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            
            if (recipe == null)
            {
                return NotFound();
            }
            else 
            {
                
                recipe.Description = System.Net.WebUtility.HtmlDecode(recipe.Description);
                recipe.Ingredients = System.Net.WebUtility.HtmlDecode(recipe.Ingredients);
                recipe.Instructions = System.Net.WebUtility.HtmlDecode(recipe.Instructions);
                Recipe = recipe;

            }
            return Page();
        }
    }
}
