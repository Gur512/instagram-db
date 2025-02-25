using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public string? CommentText { get; set; }

    public string? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
