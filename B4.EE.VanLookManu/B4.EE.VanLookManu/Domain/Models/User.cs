using Discord;
using System;
using System.Threading.Tasks;

namespace B4.EE.VanLookManu.Domain.Models
{
    public class User
    {
        public string AvatarId { get; set; }

        public string Discriminator { get; set; }

        public ushort DiscriminatorValue { get; set; }

        public bool IsBot { get; set; }

        public bool IsWebhook { get; set; }
        public string Username { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public ulong Id { get; set; }

        public string Mention { get; set; }

        public DiscordUserActivity Activity { get; set; }

        public UserStatus Status { get; set; }


        public User PopulateUser(User _user)
        {
            User user = new User();
            user.Status = _user.Status;
            user.Activity = _user.Activity;
            user.Id = _user.Id;
            user.Username = _user.Username;
            user.Discriminator = _user.Discriminator;
            user.CreatedAt = _user.CreatedAt;
            user.IsBot = _user.IsBot;
            return user;
        }
        /// <summary>
        ///  #todo  implement extra discord Iuser functions
        /// </summary>
        /// <param name="format"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public string GetAvatarUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128)
        {
            throw new NotImplementedException();
        }

        public string GetDefaultAvatarUrl()
        {
            throw new NotImplementedException();
        }

        public Task<IDMChannel> GetOrCreateDMChannelAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
    }
}
