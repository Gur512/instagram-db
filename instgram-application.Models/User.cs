using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Bio { get; set; }

    public string ProfilePicture { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<DirectMessage> DirectMessageReceiverUsers { get; set; } = new List<DirectMessage>();

    public virtual ICollection<DirectMessage> DirectMessageSenderUsers { get; set; } = new List<DirectMessage>();

    public virtual ICollection<Follow> FollowFollowerUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowingUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Story> Stories { get; set; } = new List<Story>();
}
