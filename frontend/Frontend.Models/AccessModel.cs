using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
   public class AccessModel
    {
        public long Id { get; set; }

        public long? RoleId { get; set; }

        public string AccessUrl { get; set; }

        public bool? IsActive { get; set; }

        public long? AccessProvidedBy { get; set; }

        public DateTime? AccessProvidedDate { get; set; }

        public string Name { get; set; }

        public string IconUrl { get; set; }
    }
}
