using Discord;

namespace B4.EE.VanLookManu.Domain.Models
{
    public class DiscordUserActivity : IActivity
    {
        public string Name { get; set; }

        public ActivityType Type { get; set; }
    }
}
