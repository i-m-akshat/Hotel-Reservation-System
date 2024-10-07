
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models.Room_Domain;
namespace Backend.Models.Channel_Domain
{
    public class ChannelUsed
    {

        public int Id { get; set; }

        public int? ChannelId { get; set; }

        public long? RoomId { get; set; }

        public virtual Channel? Channel { get; set; }

        public virtual Room IdNavigation { get; set; } = null!;
    }
}
