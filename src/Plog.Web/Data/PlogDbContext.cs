using System;
using Microsoft.EntityFrameworkCore;
using Plog.Web.Models;

namespace Plog.Web.Data
{
    public class PlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PlogDbContext(DbContextOptions<PlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=plog.db");
        }
    }
}
