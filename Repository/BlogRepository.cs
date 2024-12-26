using BlogPosts.DataContext;
using BlogPosts.Dtos;
using BlogPosts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlogPosts.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPostDto blogPost, string userId)
        {
            

            var blogpost = new BlogPost
            {
                Title = blogPost.Title,
                TextBody = blogPost.TextBody,
                DateCreated = DateTime.UtcNow,
                UserId = userId
            };

            _blogContext.BlogPosts.Add(blogpost);

            await _blogContext.SaveChangesAsync();

            return blogpost;
        }

        public async void DeleteBlog(int blogId)
        {
            var blog = _blogContext.BlogPosts.FirstOrDefault(blog => blog.Id == blogId);

            if(blog != null) 
            {
                _blogContext.BlogPosts.Remove(blog);
                await _blogContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogsAsync(int pageNumber, int pageSize)
        {
            return await _blogContext.BlogPosts
                .OrderByDescending(date => date.DateCreated) 
                .Skip((pageNumber - 1) * pageSize)           
                .Take(pageSize)                              
                .ToListAsync();                              
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogsByUserIdAsync(int pageNumber, int pageSize, string userId)
        {
            return await _blogContext.BlogPosts
                .Where(user=>user.UserId == userId)
                .OrderByDescending(date => date.DateCreated)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostById(int id)
        {
            var blog= await _blogContext.BlogPosts.FirstOrDefaultAsync(blog=>blog.Id==id);

            return blog;
        }
    }
}
