using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tokki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Breath_10 : ContentPage
    {
        bool game_brearth_started = false;
        int breath_mode = 0;
        int counter = 1;
        int counter_ms = 1;
        int t_5min = 304;
        int t_10min = 608;
        public Breath_10()
        {
            InitializeComponent();

            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;
            Stack_game_breath_5.IsVisible = true;
            label_Breath_5_min.Text = "10";
            label_Breath_5_sec.Text = "08";
            breath_mode = 1;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    Breath_timer();
                    //game_couple_closeall();
                });
                return counter++ > -1;

            });

            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {


                });
                return counter_ms++ > -1;

            });
        }

        public void Breath_timer()
        {
            int sec;
            int min;
            int br = 19;
            int t_min;
            switch (breath_mode)
            {
                case 1:
                    t_min = t_10min;
                    break;
                default:
                    t_min = 0;
                    break;
            }
            if (game_brearth_started && counter <= t_min)
            {


                min = ((t_min - counter) / 60);

                sec = ((t_min - counter) % 60);
                if (min > 9)
                {
                    label_Breath_5_min.Text = min.ToString();
                }
                else { label_Breath_5_min.Text = "0" + min.ToString(); }
                if (sec > 9)
                {
                    label_Breath_5_sec.Text = sec.ToString();
                }
                else { label_Breath_5_sec.Text = "0" + sec.ToString(); }

                if ((t_5min - counter) % br < 19) label_breath.Text = "inhale";
                if ((t_5min - counter) % br < 15) label_breath.Text = "holding";
                if ((t_5min - counter) % br < 8) label_breath.Text = "exhale";
                //inf.Text=( (t_5min - counter) % 19).ToString();
            }

            //label_Breath_5_sec.Text=DateTime.Now.Second.ToString();
        }
        private void Button_Breath_5_start_Click(object sender, EventArgs e)
        {

            game_brearth_started = !game_brearth_started;
            counter = 0;
            if (game_brearth_started) Button_Breath_5_start.Text = "Stop";
            else Button_Breath_5_start.Text = "Start";



        }
    }
}