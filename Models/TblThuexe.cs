using System;
using System.Collections.Generic;

namespace BTLwebNC.Models;

public partial class TblThuexe
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdTtxe { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual TblTtxe? IdTtxeNavigation { get; set; }

    public virtual TblUser? IdUserNavigation { get; set; }
}
