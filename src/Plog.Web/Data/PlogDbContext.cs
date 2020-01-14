using System;
using Microsoft.EntityFrameworkCore;
using Plog.Web.Models;

namespace Plog.Web.Data
{
    public class PlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
