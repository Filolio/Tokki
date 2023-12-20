using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Tokki.App;

namespace Tokki
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "\u25C3");
            MainPage = new NavigationPage(new MainPage());
            
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        
    }
}
