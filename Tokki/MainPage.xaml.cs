using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Tokki
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;
        }

        private async void game_breath_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu_Breath());
        }
        private async void game_couple_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu_Cauple());
        }
        private async void game_hue_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu_Hue());
        }
    }
}
