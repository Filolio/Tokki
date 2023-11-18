using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tokki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu_Cauple : ContentPage
    {
        public Menu_Cauple()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;
            Stack_game_couple.IsVisible = true;
        }

        private async void game_couple_3x4_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cauple_3x4(), false);
        }
        private async void game_couple_4x5_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cauple_4x5(), false);
        }
    }
}