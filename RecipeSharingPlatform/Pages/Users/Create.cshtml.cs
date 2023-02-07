using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;
using System.IO;
namespace RecipeSharingPlatform.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CreateModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync([FromForm] IFormFile file)
        {
         
            byte[] imageData;

            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
            }

            User.Image = imageData;
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
