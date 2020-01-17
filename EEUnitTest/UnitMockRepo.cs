using B4.EE.VanLookManu.Domain.Models;
using B4.EE.VanLookManu.Domain.Services;
using B4.EE.VanLookManu.Domain.Services.Mock;
using EEUnitTest.Mock;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xunit;

namespace EEUnitTest
{
    public class UnitMockRepo
    {
        private DiscordMockData LocalDataService;
        private RepoMockData MockData = new RepoMockData();
        private LocationService LocationService;

        [Fact]
        public async Task GetUserByValidLong()
        {
            //arange 
            LocalDataService = new DiscordMockData();
            ulong userId = 298036396768362497;
            User result = new User();

            //act 
            result = await LocalDataService.GetUserById(userId);

            // assert
            Assert.Equal(MockData.ValidUser1.Username, result.Username);
        }

        [Fact]
        public async Task NotAValidLong()
        {
            //arange 
            LocalDataService = new DiscordMockData();
            ulong userId = 5555;
            User result = new User();

            //act 
            result = await LocalDataService.GetUserById(userId);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ValidUserUpdate()
        {
            //arange 
            LocalDataService = new DiscordMockData();
            User result = new User();

            //act 
            result = await LocalDataService.UpdateUser(MockData.ValidUser1);

            // assert
            Assert.Equal(MockData.ValidUser1.Username, result.Username);
        }
        [Fact]
        public async Task NotValidUserUpdate()
        {
            //arange 
            LocalDataService = new DiscordMockData();
            User result = new User();

            //act 
            result = await LocalDataService.UpdateUser(MockData.ValidUser1);

            // assert
            Assert.NotSame(MockData.ValidUser2.Username, result.Username);
        }

        [Fact]
        public async Task CreateValidUser()
        {
            //arange 
            LocalDataService = new DiscordMockData();
            User result = new User();

            //act 
            result = await LocalDataService.CreateUser(MockData.ValidUser1);

            // assert
            Assert.Equal(MockData.ValidUser1.Username, result.Username);
        }

        [Fact]
        public async Task CreateNotValidUser()
        {
            //arange 
            LocalDataService = new DiscordMockData();
            User result = new User();

            //act 
            result = await LocalDataService.CreateUser(MockData.emtyUser1);

            // assert
            Assert.Equal(MockData.emtyUser1, result);
        }

        [Fact]
        public async Task ValidLocation()
        {
            //arange 
            LocationService = new LocationService();
            Location result = new Location();

            //act 
            result = await LocationService.Locate();

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task notEmptyLocation()
        {
            //arange 
            LocationService = new LocationService();
            Location result = new Location();

            //act 
            result = await LocationService.Locate();


            // assert
            Assert.IsType<Location>(result);
        }



    }
}
