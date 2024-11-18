using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Role_Model
    {
        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public long? Createdby { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? Deletedby { get; set; }

        public bool? IsActive { get; set; }
    }
}
