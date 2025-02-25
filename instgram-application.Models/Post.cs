using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Post
{
    public string PostId { get; set; } = null!;

    public int? UserId { get; set; }

    public string? Caption { get; set; }

    public byte[] Createdat { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual User? User { get; set; }
}
