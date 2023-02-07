using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Pages.Recipes
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name");
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "ID", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name");
                ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "ID", "Name");
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
                return Page();
            }

            Recipe.Instructions = Regex.Replace(Recipe.Instructions, "<.*?>", string.Empty);
            Recipe.Instructions = System.Text.Encodings.Web.HtmlEncoder.Default.Encode(Recipe.Instructions);

            Recipe.Description = Regex.Replace(Recipe.Description, "<.*?>", string.Empty);
            Recipe.Description = System.Text.Encodings.Web.HtmlEncoder.Default.Encode(Recipe.Description);

            Recipe.Ingredients = Regex.Replace(Recipe.Ingredients, "<.*?>", string.Empty);
            Recipe.Ingredients = System.Text.Encodings.Web.HtmlEncoder.Default.Encode(Recipe.Ingredients);

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
