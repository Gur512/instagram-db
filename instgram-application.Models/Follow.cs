using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class Follow
{
    public int FollowId { get; set; }

    public int? FollowerUserId { get; set; }

    public int? FollowingUserId { get; set; }

    public virtual User? FollowerUser { get; set; }

    public virtual User? FollowingUser { get; set; }
}
