using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace METADB.Areas.Identity.Data;

// Add profile data for application users by adding properties to the METAUser class
public class METAUser : IdentityUser
{
    [Required]
    [StringLength(256)]
    public string Username { get; set; }

    public string Pfp { get; set; }

    [StringLength(255)]
    public string ProjName { get; set; }

    public string ProjThumbnailImg { get; set; }

    public string ProjDesc { get; set; }

    // Navigation properties
    public ICollection<Posts> Posts { get; set; }
    public ICollection<Comments> Comments { get; set; }
    public ICollection<Likes> Likes { get; set; }
    public ICollection<Reports> Reports { get; set; }
}

