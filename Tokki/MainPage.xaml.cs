using System;

using Xamarin.Forms;


namespace Tokki
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void game_breath_5_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Breath_5(), false);
        }

        private async void game_breath_10_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Breath_10(), false);
        }

        private async void game_breath_15_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Breath_15(), false);
        }
        private async void game_couple_3x4_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cauple_3x4(), false);
        }
        private async void game_couple_4x5_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cauple_4x5(), false);
        }
        private async void game_hue_5x5_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hue_5x5(), false);
        }

        private async void game_hue_9x9_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hue_9x9(), false);
        }
        private async void game_lawn_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new lawn(), false);
        }
    }
}
