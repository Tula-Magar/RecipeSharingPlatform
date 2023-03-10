using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly RecipeSharingPlatform.Data.ApplicationDbContext _context;

        public IndexModel(RecipeSharingPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Comments != null)
            {
                Comment = await _context.Comments
                .Include(c => c.Recipe)
                .Include(c => c.User).ToListAsync();
            }
        }
    }
}
