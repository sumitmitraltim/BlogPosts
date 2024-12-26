using BlogPosts.DataContext;
using BlogPosts.Dtos;
using BlogPosts.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPosts.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext _blogContext;
        private readonly IBlogRepository _blogRepository;
        public CommentRepository(BlogContext blogContext, IBlogRepository blogRepository) 
        { 
            _blogContext = blogContext;
            _blogRepository = blogRepository;
        }
        public async Task<ActionResult<Comment>> CreateComment(int blogId, CommentDto comment)
        {
            if (await _blogRepository.GetBlogPostById(blogId) == null)
                return null;

            else
            {
                var commentToAdd = new Comment
                {
                    CommentText = comment.CommentText,
                    PostedOn = DateTime.UtcNow,
                    BlogPostId = blogId
                };

                _blogContext.Comments.Add(commentToAdd);

                await _blogContext.SaveChangesAsync();

                return commentToAdd;
            }
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync(int blogId)
        {
            if (await _blogRepository.GetBlogPostById(blogId) != null)
                return await _blogContext.Comments.Where(c => c.BlogPostId == blogId).OrderByDescending(date => date.PostedOn).ToListAsync();
            else
                return null;
        }

        public async Task<Comment?> GetCommentById(int blogId, int commentId)
        {
            if (await _blogRepository.GetBlogPostById(blogId) !=null)
            {
                return await _blogContext.Comments.FirstOrDefaultAsync(comment=>comment.Id==commentId);
            }

            return null;
        }
    }
}
