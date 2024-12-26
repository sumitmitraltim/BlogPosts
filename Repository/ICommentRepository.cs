using BlogPosts.Dtos;
using BlogPosts.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPosts.Repository
{
    public interface ICommentRepository
    {
        Task<Comment?> GetCommentById(int blogId, int commentId);
        Task<ActionResult<Comment>> CreateComment(int blogId,CommentDto comment);

        Task<IEnumerable<Comment>> GetAllCommentAsync(int blogId);

    }
}
