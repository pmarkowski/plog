using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plog.Web.Data;
using Plog.Web.Models;

namespace Plog.Web.Pages
{
    public class PostModel : PageModel
    {
        private PlogDbContext dbContext;

        public Post Post { get; set; }

        public PostModel(PlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> OnGetAsync(int postId)
        {
            Post = await dbContext.Posts
                .SingleOrDefaultAsync(post => post.PostId == postId);
            
            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
