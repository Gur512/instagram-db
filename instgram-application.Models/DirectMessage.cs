using System;
using System.Collections.Generic;

namespace instagram_application.Models;

public partial class DirectMessage
{
    public int MessageId { get; set; }

    public string TextMessage { get; set; } = null!;

    public int? SenderUserId { get; set; }

    public int? ReceiverUserId { get; set; }

    public byte[] SentAt { get; set; } = null!;

    public virtual User? ReceiverUser { get; set; }

    public virtual User? SenderUser { get; set; }
}
