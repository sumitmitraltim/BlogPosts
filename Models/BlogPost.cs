using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPosts.Models
{
    public class BlogPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextBody { get; set; }
        public DateTime? DateCreated { get; set; }
        public List<Comment>? Comments { get; set; } = [];
        
        public string UserId { get; set; }

    }
}
