using B4.EE.VanLookManu.Domain.Services;
using FreshMvvm;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace B4.EE.VanLookManu.ViewModels
{
    public class FunctionViewModel : FreshBasePageModel
    {

        private LocationService locationService;
        private DiscordService discordService;
        private bool isBotActive;
        public FunctionViewModel(LocationService _locationService, DiscordService _discordService)
        {
            this.locationService = _locationService;
            this.discordService = _discordService;
            isBotActive = false;
        }

        #region - Properties -
        public bool IsBotActive
        {
            get { return isBotActive; }
            set
            {
                isBotActive = value;
                RaisePropertyChanged(nameof(IsBotActive));
            }
        }
        #endregion

        #region - Commands -
        public ICommand SendLocationCommand => new Command<ItemTappedEventArgs>(
        async (ItemTappedEventArgs args) =>
        {
            Location location = await locationService.Locate();
            {

                var response = discordService.PostMessage("manu", $"lat = {location.Latitude}, long = {location.Longitude}");
                await CoreMethods.DisplayAlert("alert", response, "ok");

            }
        });

        public ICommand OpenUsersCommand => new Command(
           async () =>
           {
               if (!isBotActive)
               {
                   await CoreMethods.PushPageModel<UserActivityViewModel>(isBotActive, false, true);
               }
               else
               {
                   await CoreMethods.DisplayAlert("alert", "bot is active try something else", "ok");
               }

           });

        public ICommand OpenUserActivities => new Command(
            async () =>
            {

                if (isBotActive)
                {
                    await CoreMethods.PushPageModel<UserActivityViewModel>(isBotActive, false, true);
                }
                else
                {
                    await CoreMethods.DisplayAlert("alert", "bot is not active try something else", "ok");
                }
            });

        public ICommand StartBot => new Command<ItemTappedEventArgs>(
         async (ItemTappedEventArgs args) =>
         {
             if (await discordService.StartClientAsync())
             {
                 await CoreMethods.DisplayAlert("Alert", "started client", "ok");

                 IsBotActive = true;
             }
             else
             {
                 await CoreMethods.DisplayAlert("alert", "Client can't start", "ok");
             }
         });

        public ICommand StopBot => new Command<ItemTappedEventArgs>(
         async (ItemTappedEventArgs args) =>
         {
             if (await discordService.StopClientAsync())
             {
                 isBotActive = false;
             }
             else
             {
                 await CoreMethods.DisplayAlert("Alert", "something went wrong! Couldn't stop the bot", "ok");
             }
         });

        #endregion


    }
}
