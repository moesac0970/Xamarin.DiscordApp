using System;

namespace B4.EE.VanLookManu.Domain.Models
{
    public class GuildMember
    {
        public User User { get; set; }
        public string[] roles { get; set; }
        public string nick { get; set; }
        public string premium_since { get; set; }
        public bool Mute { get; set; }
        public bool Dead { get; set; }
        public DateTimeOffset Joined_at { get; set; }
    }
}
