using System;
using System.Collections.Generic;

namespace BTLwebNC.Models;

public partial class TblContact
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public string? Title { get; set; }

    public int? IdUser { get; set; }

    public virtual TblUser? IdUserNavigation { get; set; }
}
