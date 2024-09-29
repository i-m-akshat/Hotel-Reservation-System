using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Admin_Domain
{
    public class Access
    {

        public long Id { get; set; }

        public long? RoleId { get; set; }

        public string? AccessUrl { get; set; }

        public bool? IsActive { get; set; }

        public long? AccessProvidedBy { get; set; }

        public DateTime? AccessProvidedDate { get; set; }

        public string? Name { get; set; }

        public string? IconUrl { get; set; }

        public virtual AdminSession? AccessProvidedByNavigation { get; set; }

        public virtual Role? Role { get; set; }
    }
}
