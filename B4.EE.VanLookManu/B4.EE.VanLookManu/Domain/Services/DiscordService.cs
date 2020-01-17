using B4.EE.VanLookManu.Domain.Const;
using B4.EE.VanLookManu.Domain.Models;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace B4.EE.VanLookManu.Domain.Services
{
    public class DiscordService
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        private IDiscordData data;

        public DiscordService(IDiscordData _data)
        {
            data = _data;
        }

        public async Task<bool> StartClientAsync()
        {
            try
            {
                //register dependencies and instances
                _client = new DiscordSocketClient();
                _commands = new CommandService();
                _services = new ServiceCollection()
                    .AddSingleton(_client)
                    .AddSingleton(_commands)
                    .BuildServiceProvider();

                //login bot to server
                await _client.LoginAsync(TokenType.Bot, GlobalConst.DiscordBotToken);
                await _client.StartAsync();



                _client.MessageReceived += HandleCommandAsync;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> StopClientAsync()
        {
            try
            {
                await _client.StopAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }



        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            int argumentPosition = 0;

            if (message.HasStringPrefix("all!", ref argumentPosition) || message.HasMentionPrefix(_client.CurrentUser, ref argumentPosition))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argumentPosition, _services);

                CacheMode cacheMode = new CacheMode();
                var users = await Task.FromResult(context.Channel.GetUsersAsync(cacheMode, new RequestOptions()).ToEnumerable());

                foreach (var _user in users)
                {
                    foreach (var usert in _user)
                    {
                        User user = new User
                        {
                            Activity = new DiscordUserActivity()
                        };

                        user.Status = usert.Status;
                        if (usert.Activity == null)
                        {
                            user.Activity.Name = "not playing";
                        }
                        else
                        {
                            user.Activity.Name = usert.Activity.Name;
                        }

                        user.Id = usert.Id;
                        user.Username = usert.Username;
                        user.Discriminator = usert.Discriminator;
                        user.CreatedAt = usert.CreatedAt;
                        user.IsBot = usert.IsBot;
                        await data.CreateUser(user);
                    }
                }

            }
        }
        public async Task<IList<User>> GetUsers()
        {
            List<GuildMember> GuilUsers = new List<GuildMember>();
            List<User> users = new List<User>();

            // 
            HttpClient client = new HttpClient();
            Uri uri = new Uri(GlobalConst.DiscordUserApi);
            client.DefaultRequestHeaders.Add("Authorization", $"Bot {GlobalConst.DiscordBotToken}");


            string reponse = await client.GetStringAsync(uri);
            GuilUsers = JsonConvert.DeserializeObject<List<GuildMember>>(reponse);
            foreach (var user in GuilUsers)
            {
                users.Add(user.User);
            }

            return users;
        }


        public string PostMessage(string username, string content)
        {
            try
            {
                Uri url = new Uri(GlobalConst.DiscordWebHook);
                using (WebClient webclient = new WebClient())
                    webclient.UploadValuesAsync(url, new NameValueCollection()
                    {
                        {
                            "username",
                            username
                        },
                        {
                            "content",
                            content
                        }

                    });

                return "location sent";
            }
            catch
            {
                return "coulnd't connect to the internet, location dind't sent";
            }


        }
    }
}
