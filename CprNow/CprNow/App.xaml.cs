using CprNow.Services;
using CprNow.ViewModels;
using CprNow.Views;
using Xamarin.Forms;

namespace CprNow
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }
    }
}