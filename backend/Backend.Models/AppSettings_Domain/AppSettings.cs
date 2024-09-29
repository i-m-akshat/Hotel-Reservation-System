using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.AppSettings_Domain
{
    public class AppSettings
    {
        public string enc_key { get; set; }
        public string enc_iv { get; set; }
    }
}
