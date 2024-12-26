using BlogPosts.Authentication;
using BlogPosts.Dtos;
using BlogPosts.Models;
using BlogPosts.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPosts.Controllers
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICommentRepository _commentRepository;


        public BlogController(IBlogRepository blogRepository,ICommentRepository commentRepository)
        { 
            _blogRepository = blogRepository;
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllBlogs([FromQuery]int pageNumber=1,[FromQuery] int pageSize=10)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync(pageNumber,pageSize);

            return Ok(blogs);
        }


        public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllBlogsByUserId([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var userId = User.FindFirst("userId").ToString();

            var blogs = await _blogRepository.GetAllBlogsByUserIdAsync(pageNumber, pageSize,userId);

            return Ok(blogs);
        }


        [HttpGet("{id}",Name="GetBlogById")]
        public async Task<ActionResult<BlogPost>> GetBlogById(int id)
        {
            
            var blog = await _blogRepository.GetBlogPostById(id);

            if (blog == null)
            {
                return NotFound("No Blogs Present");
            }

            var comments = await _commentRepository.GetAllCommentAsync(id);

            blog.Comments=comments.ToList();

            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPostDto blogPost)
        {

            var userId = User.FindFirst("userId").ToString();

            if (ModelState.IsValid)
            {
                var blog = await _blogRepository.CreateBlogPost(blogPost,userId);

                if (blog == null)
                {
                    return BadRequest();
                }

                return CreatedAtRoute("GetBlogById", new {id=blog.Value.Id},blog);
            }
            else { return BadRequest(); }
        }



        [HttpDelete("{blogId}")]
        public ActionResult Delete(int blogId)
        {
            _blogRepository.DeleteBlog(blogId);

            return NoContent();
        }


    }
}
