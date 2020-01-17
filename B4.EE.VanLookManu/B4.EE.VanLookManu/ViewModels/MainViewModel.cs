using B4.EE.VanLookManu.Domain.Services;
using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.VanLookManu.ViewModels
{
    class MainViewModel : FreshBasePageModel
    {
        private DiscordService discordService;
        private LocationService locationService;

        public MainViewModel(DiscordService _discordService)
        {
            discordService = _discordService;
            locationService = new LocationService();

        }

        public ICommand GoToFunctionPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<FunctionViewModel>();

           });






    }
}
