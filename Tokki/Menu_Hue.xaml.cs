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
    public partial class Menu_Hue : ContentPage
    {
        public Menu_Hue()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;
            Stack_game_hue.IsVisible = true;
        }

        private async void game_hue_5x5_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hue_5x5(), false);
        }

        private async void game_hue_9x9_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hue_9x9(), false);
        }

       
    }
}