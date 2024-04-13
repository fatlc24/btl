using System;
using System.Collections.Generic;

namespace BTLwebNC.Models;

public partial class TblTtxe
{
    public int Id { get; set; }

    public string? Tenxe { get; set; }

    public int? IdUser { get; set; }

    public string? Image { get; set; }

    public string? Status { get; set; }

    public int? Namsanxuat { get; set; }

    public string? Tien { get; set; }

    public string? IsCheck { get; set; }

    public int? Publish {  get; set; }

    public virtual TblUser? IdUserNavigation { get; set; }

    public virtual ICollection<TblThuexe> TblThuexes { get; set; } = new List<TblThuexe>();
}
