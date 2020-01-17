using B4.EE.VanLookManu.Domain;
using B4.EE.VanLookManu.Domain.Models;
using B4.EE.VanLookManu.Domain.Services;
using Discord;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.VanLookManu.ViewModels
{
    public class UserActivityViewModel : FreshBasePageModel
    {
        private readonly IDiscordData data;
        private DiscordService discordService;
        private bool? WithBot;
        public bool IsActive;

        public UserActivityViewModel(IDiscordData _data, DiscordService _discordService)
        {
            this.data = _data;
            this.discordService = _discordService;
            IsActive = true;

        }

        #region - Properties -

        private ObservableCollection<User> currentUsers;
        public ObservableCollection<User> CurrentUsers
        {
            get { return currentUsers; }
            set
            {
                currentUsers = value;
                RaisePropertyChanged(nameof(CurrentUsers));
            }
        }

        private bool isOnline;
        public bool IsOnline
        {
            get { return isOnline; }
            set
            {
                isOnline = value;
                RaisePropertyChanged(nameof(IsOnline));
            }
        }
        #endregion

        #region - Commands -
        public ICommand OpenUserActivity => new Command<ItemTappedEventArgs>(
         async (ItemTappedEventArgs args) =>
         {
             await CoreMethods.PushPageModel<UserDetailViewModel>((args.Item as User), false, true);
         });

        public ICommand RefreshActivity => new Command<ItemTappedEventArgs>(
        async (ItemTappedEventArgs args) =>
        {

            if (WithBot == true)
            {
                discordService.PostMessage("manu", "all!");
                var users = await data.GetUsersAsync();
                RefreshData(users);
            }
            else
            {
                var users = await discordService.GetUsers();
                RefreshData(users);
            }
        });
        #endregion

        #region - Overrides -
        public async override void Init(object initData)
        {
            base.Init(initData);
            WithBot = initData as bool?;
            if (WithBot == true)
            {
                var users = await data.GetUsersAsync();
                await LoadUsersFromBot(users);
            }
            else
            {
                try
                {
                    IsOnline = false;
                    var users = await discordService.GetUsers();
                    await LoadUsersFromBot(users);
                }
                catch
                {
                    await CoreMethods.DisplayAlert("Alert", "App is not connected to internet", "ok");
                }
            }
        }
        #endregion

        private async Task LoadUsersFromBot(IList<User> users)
        {
            CurrentUsers = null;
            CurrentUsers = new ObservableCollection<User>(users.OrderBy(u => u.Username));
            await EnsureData();
        }

        private void RefreshData(IList<User> users)
        {
            CurrentUsers = null;
            CurrentUsers = new ObservableCollection<User>(users.OrderBy(u => u.Username));
        }

        private async Task EnsureData()
        {
            if (CurrentUsers == null || currentUsers.Count() == 0)
            {
                var user = new User
                {
                    Username = "PingPongMashien",
                    Id = 298036396768362497,
                    Activity = new DiscordUserActivity { Name = "rocket league", Type = ActivityType.Playing },
                    IsBot = false,
                    Status = UserStatus.Idle,
                    CreatedAt = new DateTime(2017, 6, 25),
                    Discriminator = "9933"
                };
                var users = new List<User>();
                users.Add(user);
                CurrentUsers = null;
                CurrentUsers = new ObservableCollection<User>(users.OrderBy(u => u.Username));
                await data.CreateUser(user);
            }


        }

    }
}
