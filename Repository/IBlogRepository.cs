using BlogPosts.Dtos;
using BlogPosts.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPosts.Repository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogPost>> GetAllBlogsAsync(int pageNumber,int pageSize);

        Task<BlogPost> GetBlogPostById(int id);

        Task<ActionResult<BlogPost>> CreateBlogPost(BlogPostDto blogPost,string userId);

        Task<IEnumerable<BlogPost>> GetAllBlogsByUserIdAsync(int pageNumber, int pageSize,string userId);

        void DeleteBlog(int blogId);
    }
}
