using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Storyview
{
    public int? UserId { get; set; }

    public int? StoryId { get; set; }

    public byte[] ViewedAt { get; set; } = null!;

    public virtual Story? Story { get; set; }

    public virtual User? User { get; set; }
}
