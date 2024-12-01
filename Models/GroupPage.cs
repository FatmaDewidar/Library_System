using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class GroupPage
{
    public int? GroupPageId { get; set; }

    public int? GroupId { get; set; }

    public int? PageId { get; set; }

    public bool? Show { get; set; }

    public bool? Add { get; set; }

    public bool? Edit { get; set; }

    public bool? Delete { get; set; }
}
