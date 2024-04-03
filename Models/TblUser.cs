using System;
using System.Collections.Generic;

namespace BTLwebNC.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TblContact> TblContacts { get; set; } = new List<TblContact>();

    public virtual ICollection<TblNews> TblNews { get; set; } = new List<TblNews>();

    public virtual ICollection<TblThuexe> TblThuexes { get; set; } = new List<TblThuexe>();

    public virtual ICollection<TblTtxe> TblTtxes { get; set; } = new List<TblTtxe>();
}
