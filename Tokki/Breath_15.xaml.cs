using System;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tokki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Breath_15 : ContentPage
    {
        bool game_brearth_started = false;
        int breath_mode = 0;
        int counter = 1;

        int t_5min = 304;
        int t_15min = 912;
        public Breath_15()
        {
            InitializeComponent();
            Stack_game_breath_5.IsVisible = true;
            label_Breath_5_min.Text = "15";
            label_Breath_5_sec.Text = "12";
            breath_mode = 1;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Breath_timer();
                });
                return counter++ > -1;

            });

        }

        int ima = 0;
        public void Breath_timer()
        {
            int sec;
            int min;
            int br = 19;
            int t_min;
            switch (breath_mode)
            {
                case 1:
                    t_min = t_15min;
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

                if ((t_5min - counter) % br < 19 && (t_5min - counter) % br >= 15)
                {
                    label_breath.Text = "вдох";
                    if (ima != 1)
                    {
                        ima = 1;
                        Image_breath_15.Source ="inhale.png";
                    }
                }
                if ((t_5min - counter) % br < 15 && (t_5min - counter) % br >= 8)
                {
                    label_breath.Text = "держи";
                    if (ima != 2)
                    {
                        ima = 2;
                        Image_breath_15.Source ="holding.png";
                    }                   
                }
                if ((t_5min - counter) % br < 8)
                {
                    label_breath.Text = "выдох";
                    if (ima != 3)
                    {
                        ima = 3;
                        Image_breath_15.Source = "exhale.png";
                    }
                }
            }
        }
        private void Button_Breath_5_start_Click(object sender, EventArgs e)
        {

            game_brearth_started = !game_brearth_started;
            counter = 0;
            if (game_brearth_started) Button_Breath_5_start.Source = "stop.png";
            else Button_Breath_5_start.Source = "start.png";



        }
        private async void game_breath_15_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(false);
            base.OnBackButtonPressed();
            return false;
        }
    }
}