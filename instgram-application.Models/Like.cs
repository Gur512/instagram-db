using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Like
{
    public int LikeId { get; set; }

    public string? PostId { get; set; }

    public int? UserId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
