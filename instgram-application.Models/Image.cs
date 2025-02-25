using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public byte[] UploadedAt { get; set; } = null!;

    public int? UserId { get; set; }

    public string? PostId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
