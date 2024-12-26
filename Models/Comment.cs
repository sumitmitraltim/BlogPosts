using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPosts.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CommentText { get; set; }

        [ForeignKey("BlogPosts")]
        public int BlogPostId {  get; set; }   
        public DateTime PostedOn { get; set; }
    }
}
