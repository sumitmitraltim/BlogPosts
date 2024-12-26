using BlogPosts.DataContext;
using BlogPosts.Dtos;
using BlogPosts.Models;
using BlogPosts.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPosts.Controllers
{
    [Route("api/blogs/{blogId}/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        
        public CommentController(ICommentRepository commentRepository) 
        {
            _commentRepository = commentRepository;
            
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(int blogId, [FromBody]CommentDto commentDto)
        {
            var commentToAdd=await _commentRepository.CreateComment(blogId, commentDto);

            if (commentToAdd == null)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpGet("{commentId}")]
        public async Task<ActionResult> GetCommentById(int blogId, int commentId)
        {
            var comment = await _commentRepository.GetCommentById(blogId, commentId);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAllCommentAsync(int blogId)
        {
            var comments=await _commentRepository.GetAllCommentAsync(blogId);

            return Ok(comments);
        }
    }
}
