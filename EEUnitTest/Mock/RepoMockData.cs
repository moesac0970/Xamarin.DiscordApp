using B4.EE.VanLookManu.Domain.Models;
using Discord;
using System;

namespace EEUnitTest.Mock
{
    public class RepoMockData
    {

        public User ValidUser1 = new User
        {
            Username = "PingPongMashien",
            Id = 298036396768362497,
            Activity = new DiscordUserActivity { Name = "rocket league", Type = ActivityType.Playing },
            IsBot = false,
            Status = UserStatus.Idle,
            CreatedAt = new DateTime(2017, 6, 25),
            Discriminator = "9933"
        };
        public User ValidUser2 = new User
        {
            Username = "TennisBal9000",
            Id = 298036396768362497,
            Activity = new DiscordUserActivity { Name = "Microsoft Visual Studio", Type = ActivityType.Playing },
            IsBot = false,
            Status = UserStatus.Idle,
            CreatedAt = new DateTime(2017, 6, 25),
            Discriminator = "1120"
        };
        public User ValidUser3 = new User
        {
            Username = "IEATGLUE",
            Id = 298036396768362497,
            Activity = new DiscordUserActivity { Name = "League of legends", Type = ActivityType.Playing },
            IsBot = false,
            Status = UserStatus.Idle,
            CreatedAt = new DateTime(2017, 6, 25),
            Discriminator = "1390"
        };

        public User emtyUser1 = new User
        {

        };

        public User NotValidUser1FAtId = new User
        {
            Username = "IEATGLUE",
            Id = 5555,
            Activity = new DiscordUserActivity { Name = "League of legends", Type = ActivityType.Playing },
            Status = UserStatus.Idle,
            CreatedAt = new DateTime(2017, 6, 25),
            Discriminator = "1390"
        };

        public User NotValidUser1FAtUName = new User
        {
            Username = "",
            Id = 298036396768362497,
            Activity = new DiscordUserActivity { Name = "League of legends", Type = ActivityType.Playing },
            Status = UserStatus.Idle,
            CreatedAt = new DateTime(2017, 6, 25),
            Discriminator = "1390"
        };

        public User NotValidUser1FAtCreatedAt = new User
        {
            Username = "IEATGLUE",
            Id = 298036396768362497,
            Activity = new DiscordUserActivity { Name = "League of legends", Type = ActivityType.Playing },
            Status = UserStatus.Idle,
            // no created at
            Discriminator = "1390"
        };

        public User NotValidUser1FAtDiscriminator = new User
        {
            Username = "IEATGLUE",
            Id = 298036396768362497,
            Activity = new DiscordUserActivity { Name = "League of legends", Type = ActivityType.Playing },
            Status = UserStatus.Idle,
            CreatedAt = new DateTime(2017, 6, 25),
            Discriminator = ""
        };


    }
}
