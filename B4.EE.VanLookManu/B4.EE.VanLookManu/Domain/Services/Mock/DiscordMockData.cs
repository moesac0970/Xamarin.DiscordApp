using B4.EE.VanLookManu.Domain.Models;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B4.EE.VanLookManu.Domain.Services.Mock
{
    public class DiscordMockData : IDiscordData
    {

        private static List<User> _users = new List<User>
        {
            new User
            {
                Username = "PingPongMashien",
                Id = 298036396768362497,
                Activity = new DiscordUserActivity{Name = "rocket league", Type = ActivityType.Playing},
                IsBot = false,
                Status = UserStatus.Idle,
                CreatedAt = new DateTime(2017,6,25),
                Discriminator = "9933"
            },
            new User
            {
                Username = "TennisBal9000",
                Id = 298036396768362497,
                Activity = new DiscordUserActivity{Name = "Microsoft Visual Studio", Type = ActivityType.Playing},
                IsBot = false,
                Status = UserStatus.Idle,
                CreatedAt = new DateTime(2017,6,25),
                Discriminator = "1120"
            },
            new User
            {
                Username = "IEATGLUE",
                Id = 298036396768362497,
                Activity = new DiscordUserActivity{Name = "League of legends", Type = ActivityType.Playing},
                IsBot = false,
                Status = UserStatus.Idle,
                CreatedAt = new DateTime(2017,6,25),
                Discriminator = "1390"
            }
        };

        public async Task<User> CreateUser(User user)
        {
            if (user != null)
            {
                _users.Add(user);
                return await Task.FromResult(user);
            }
            else
                return await Task.FromResult(user);
        }

        public async Task<User> GetUserById(ulong id)
        {
            var user = _users.Where(u => u.Id == id)
                            .FirstOrDefault();
            return await Task.FromResult(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            var OlUser = _users.FirstOrDefault(u => u.Id == user.Id);
            _users.Remove(OlUser);
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            var users = _users;
            return await Task.FromResult(users);
        }
    }
}
