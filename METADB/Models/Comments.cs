using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace METADB.Models
{
    public class Comments
    {
        [Key]
        public int CommentsID { get; set; }

        [Required]
        public int PostsID { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        public string Id { get; set; }


        [Required]
        public bool Correct { get; set; }

        // Navigation properties
        public Posts Post { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Likes> Likes { get; set; }
        public ICollection<Reports> Reports { get; set; }

        [NotMapped]
        public int LikesCount { get; set; } // Number of Likes for the post

    }
}
