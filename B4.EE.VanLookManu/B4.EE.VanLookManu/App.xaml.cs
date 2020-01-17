using B4.EE.VanLookManu.Domain;
using B4.EE.VanLookManu.Domain.Services.Local;
using B4.EE.VanLookManu.ViewModels;
using FreshMvvm;
using Xamarin.Forms;

namespace B4.EE.VanLookManu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //register dependencies
            FreshIOC.Container.Register<IDiscordData>(new DiscordLocalData());


            //MainPage = new StartPage();
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            // #todo handle bot logic
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            // #todo handle bot logic

        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            // #todo handle bot logic

        }
    }
}
