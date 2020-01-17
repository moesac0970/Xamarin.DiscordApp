using B4.EE.VanLookManu.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace B4.EE.VanLookManu.Domain.Services.Local
{
    /// <summary>
    /// repo made for P4PE3 but reused
    /// </summary>
    public class DiscordLocalData : IDiscordData
    {
        private readonly string _filePath;
        private readonly JsonSerializerSettings _serializerSettings;

        public DiscordLocalData()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "discord.json");

            //prevent self-referencing loops when saving Json
            _serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }


        public async Task<User> GetUserById(ulong id)
        {
            var users = await GetAllUsers();
            return users.FirstOrDefault(e => e.Id == id);
        }

        public async Task<User> UpdateUser(User user)
        {
            var users = await GetAllUsers();
            var userToUpdate = users.FirstOrDefault(e => e.Id == user.Id);
            users.Remove(userToUpdate);
            users.Add(user);
            SaveUsersToJsonFile(users);
            return users.FirstOrDefault(e => e.Id == user.Id);
        }

        public async Task<User> CreateUser(User user)
        {
            if (user != null)
            {

                var users = await GetUsersAsync();
                var oUser = await GetUserById(user.Id) ?? new User { Id = (ulong)0 };
                if (oUser.Id == user.Id)
                {
                    await UpdateUser(user);
                }
                else
                {
                    //todo add mapping or create ctor for user
                    users.Add(new User
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Activity = user.Activity,
                        CreatedAt = user.CreatedAt,
                        Discriminator = user.Discriminator
                    });
                    SaveUsersToJsonFile(users.AsEnumerable());
                }

                return await GetUserById(user.Id);
            }
            else
                return await Task.FromResult(user);
        }

        protected async Task<IList<User>> GetAllUsers()
        {
            try
            {
                string usersJson = File.ReadAllText(_filePath);
                var users = JsonConvert.DeserializeObject<IList<User>>(usersJson);
                return await Task.FromResult(users);  //using Task.FromResult to have atleast one await in this async method
            }
            catch  //return empty collection on file not found, deserialization error, ...
            {
                return new List<User>();
            }
        }




        protected void SaveUsersToJsonFile(IEnumerable<User> users)
        {
            string usersJson = JsonConvert.SerializeObject(users, Formatting.Indented, _serializerSettings);
            File.WriteAllText(_filePath, usersJson);
        }



        public async Task<IList<User>> GetUsersAsync()
        {
            try
            {
                string usersJson = File.ReadAllText(_filePath);
                var users = JsonConvert.DeserializeObject<IList<User>>(usersJson);
                return await Task.FromResult(users);  //using Task.FromResult to have atleast one await in this async method
            }
            catch (Exception ex)  //return empty collection on file not found, deserialization error, ...
            {
                Console.WriteLine(ex);
                return new List<User>();
            }
        }






    }
}
