using System.ComponentModel.DataAnnotations;

namespace BlogPosts.Dtos
{
    public class BlogPostDto
    {
        [Required(ErrorMessage ="Blog Title cannot be Empty")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Blog Text Body cannot be Empty")]
        public string TextBody { get; set; }


    }
}
