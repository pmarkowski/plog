using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Plog.Web.Data;
using Plog.Web.Models;

namespace Plog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly PlogDbContext dbContext;

        public List<Post> Posts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Plog.Web.Data.PlogDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public void OnGetAsync()
        {
            Posts = await dbContext.Posts
                .OrderByDescending(post => post.Created)
                .Take(10)
                .ToListAsync();
        }
    }
}
