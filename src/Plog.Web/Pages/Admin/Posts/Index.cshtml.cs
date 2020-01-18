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
    public class IndexModel : PageModel
    {
        private readonly PlogDbContext context;

        public IndexModel(PlogDbContext context)
        {
            this.context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = (await context.Posts
                .ToListAsync())
                .OrderByDescending(post => post.Created)
                .ToList();
        }
    }
}
