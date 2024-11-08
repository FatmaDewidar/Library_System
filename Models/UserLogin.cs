using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class UserLogin
{
    public int UserLoginId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsSuccess { get; set; }

    public string? IpAddress { get; set; }

    public virtual User User { get; set; } = null!;
}
