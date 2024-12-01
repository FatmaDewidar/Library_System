using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class Page
{
    public int? PageId { get; set; }

    public string? PageName { get; set; }

    public string? PageLink { get; set; }

    public string? PageCode { get; set; }

    public int? PageSort { get; set; }
}
