using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plog.Web.Data;
using Plog.Web.Models;

namespace Plog.Web.Pages.Admin.Posts
{
    public class DeleteModel : PageModel
    {
        private readonly PlogDbContext context;

        public DeleteModel(PlogDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await context.Posts.FirstOrDefaultAsync(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await context.Posts.FindAsync(id);

            if (Post != null)
            {
                context.Posts.Remove(Post);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
