using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPosts.Dtos
{
    public class CommentDto
    {
        [Required]
        public string CommentText { get; set; }

    }
}
