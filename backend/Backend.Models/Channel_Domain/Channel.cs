
using Backend.Domain.Session_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Channel_Domain
{
    public class Channel
    {
        public int ChannelId { get; set; }

        public string? ChannelName { get; set; }

        public string? Details { get; set; }

        public DateTime? Createddate { get; set; }

        public long? Createdby { get; set; }

        public DateTime? Updateddate { get; set; }

        public long? Updatedby { get; set; }

        public DateTime? Deleteddate { get; set; }

        public long? Deletedby { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }

        public virtual AdminSession? DeletedbyNavigation { get; set; }

        public virtual ICollection<ChannelUsed> Channeluseds { get; set; } = new List<ChannelUsed>();

        public virtual AdminSession? UpdatedbyNavigation { get; set; }
    }

}
