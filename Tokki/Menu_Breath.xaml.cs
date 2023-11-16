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
	public partial class Menu_Breath : ContentPage
	{
		public Menu_Breath ()
		{
			InitializeComponent ();

            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;
           // Stack_main_menu.IsVisible = false;
            Stack_game_breath.IsVisible = true;
        }
        private async void game_breath_5_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Breath_5(), false);
            //Stack_game_breath.IsVisible = false;
        }

        private async void game_breath_10_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Breath_10(), false);
           // Stack_game_breath.IsVisible = false;
        }

        private async void game_breath_15_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Breath_15(), false);
            //Stack_game_breath.IsVisible = false;
        }
    }
}