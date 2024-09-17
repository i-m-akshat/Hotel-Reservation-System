

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Session_Domain
{
    public class AdminSession
    {
        public long SessionId { get; set; }

        public long? AdminId { get; set; }

        public DateTime? SessionStart { get; set; }

        public DateTime? SessionEnd { get; set; }

        public string? DeviceType { get; set; }

        public string? Devicelocation { get; set; }

        public string? IpAddress { get; set; }
    }
}
