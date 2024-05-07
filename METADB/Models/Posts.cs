using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace METADB.Models
{
    public class Posts
    {
        [Key]
        public int PostsID { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        public string Title { get; set; }

        [Required]
        public bool Locked { get; set; }

        [Required]
        public string Id { get; set; }

        // Navigation properties
        public IdentityUser User { get; set; }
        public ICollection<Likes> Likes { get; set; }
        public ICollection<Reports> Reports { get; set; }
        public ICollection<Comments> Comments { get; set; }

        [NotMapped] // This property is not stored in the database
        public int CommentsCount { get; set; } // Number of comments for the post
        [NotMapped]
        public int LikesCount { get; set; } // Number of Likes for the post
    }
}
