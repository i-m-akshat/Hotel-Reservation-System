using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblAccess
{
    public long Id { get; set; }

    public long? RoleId { get; set; }

    public string? AccessUrl { get; set; }

    public bool? IsActive { get; set; }

    public long? AccessProvidedBy { get; set; }

    public DateTime? AccessProvidedDate { get; set; }

    public string? Name { get; set; }

    public string? IconUrl { get; set; }

    public virtual TblAdminSession? AccessProvidedByNavigation { get; set; }

    public virtual TblRole? Role { get; set; }
}
