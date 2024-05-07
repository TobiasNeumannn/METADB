using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace METADB.Models
{
    public class Likes
    {
        [Key]
        public int LikesID { get; set; }

        public string Id { get; set; }
        public int? PostsID { get; set; }
        public int? CommentsID { get; set; }

        // Navigation properties
        public IdentityUser User { get; set; }
        public Posts Post { get; set; }
        public Comments Comment { get; set; }
    }
}
