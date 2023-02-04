using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

        public EditModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }
            Recipe = recipe;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name");
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "ID", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Recipe.Description == "&nbsp;")
            {
                Recipe.Description = "";
            }

            if (Recipe.Ingredients == "&nbsp;")
            {
                Recipe.Ingredients = "";
            }

            if (Recipe.Instructions == "&nbsp;")
            {
                Recipe.Instructions = "";
            }


            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name");
                ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "ID", "Name");
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
                return Page();
            }

            _context.Attach(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.RecipeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
          return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}
