using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Story
{
    public int StoryId { get; set; }

    public int? UserId { get; set; }

    public string? Caption { get; set; }

    public DateTime? ExpirationTime { get; set; }

    public byte[] UploadedAt { get; set; } = null!;

    public virtual User? User { get; set; }
}
