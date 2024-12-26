using BlogPosts.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPosts.DataContext
{
    public class BlogContext : DbContext
    {

        public BlogContext() { }
        public BlogContext(DbContextOptions<BlogContext> dbContextOptions):base(dbContextOptions) { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BlogPosts.db");
        }
        public DbSet<BlogPost> BlogPosts {  get; set; }
        public DbSet<Comment> Comments { get; set; }
        

    }
}
