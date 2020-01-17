using B4.EE.VanLookManu.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B4.EE.VanLookManu.Domain
{
    public interface IDiscordData
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(ulong id);
        Task<IList<User>> GetUsersAsync();
        Task<User> UpdateUser(User user);
    }
}
