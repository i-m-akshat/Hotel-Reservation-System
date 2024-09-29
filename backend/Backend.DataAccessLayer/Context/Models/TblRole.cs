using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblRole
{
    public long RoleId { get; set; }

    public string? Role { get; set; }

    public long? Createdby { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public long? Deletedby { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblAdminSession? CreatedbyNavigation { get; set; }

    public virtual TblAdminSession? DeletedbyNavigation { get; set; }

    public virtual ICollection<TblAccess> TblAccesses { get; set; } = new List<TblAccess>();

    public virtual TblAdminSession? UpdatedByNavigation { get; set; }
}
