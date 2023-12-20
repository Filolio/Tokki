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
    public partial class Cauple_3x4 : ContentPage
    {
        int[] indexes_3x4 = { 2, 2, 2, 2, 2, 2 };
        int[] indexes_4x5 = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        int c;
        int k;
        int par34;
        ImageButton a;
        ImageButton b;
        public Cauple_3x4()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;

            new_game_couple_3x4();
        }

        private void new_game_couple_3x4()
        {
            k = 0;
            par34 = 0;
            Button_couple_3x4_retry.Text = "Give up";
            card00.TabIndex = game_couple_3x4_getindex();
            card01.TabIndex = game_couple_3x4_getindex();
            card02.TabIndex = game_couple_3x4_getindex();
            card03.TabIndex = game_couple_3x4_getindex();
            card10.TabIndex = game_couple_3x4_getindex();
            card11.TabIndex = game_couple_3x4_getindex();
            card12.TabIndex = game_couple_3x4_getindex();
            card13.TabIndex = game_couple_3x4_getindex();
            card20.TabIndex = game_couple_3x4_getindex();
            card21.TabIndex = game_couple_3x4_getindex();
            card22.TabIndex = game_couple_3x4_getindex();
            card23.TabIndex = game_couple_3x4_getindex();
            for (int i = 0; i < 6; i++)
            {
                indexes_3x4[i] = 2;
            }
            game_couple_3x4_closeall();
            Stack_game_couple_3x4.IsVisible = true;
        }

        private async void game_couple_3x4_Click(object sender, EventArgs e)
        {
            new_game_couple_3x4();
        }
        private int game_couple_3x4_getindex()
        {
            var rand = new Random();
            while (true)
            {
                c = rand.Next(1, 7);
                if (indexes_3x4[c - 1] > 0)
                {
                    indexes_3x4[c - 1]--;
                    break;
                }
            }
            return c;
        }
        private void game_couple_3x4_closeall()
        {
            (card00).TabIndex += 100;
            (card00).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card01).TabIndex += 100;
            (card01).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card02).TabIndex += 100;
            (card02).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card03).TabIndex += 100;
            (card03).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card10).TabIndex += 100;
            (card10).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card11).TabIndex += 100;
            (card11).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card12).TabIndex += 100;
            (card12).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card13).TabIndex += 100;
            (card13).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card20).TabIndex += 100;
            (card20).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (card21).TabIndex += 100;
            (card21).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");


            (card22).TabIndex += 100;
            (card22).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");


            (card23).TabIndex += 100;
            (card23).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");
        }

        private void game_couple_3x4_field_Click(object sender, EventArgs e)
        {
            if (((ImageButton)sender).TabIndex > 100)
            {
                ((ImageButton)sender).TabIndex -= 100;
                ((ImageButton)sender).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + ((ImageButton)sender).TabIndex.ToString() + ".jpg");
                if (k == 0 || k == 2)
                {

                    if (k == 2)
                    {
                        k = 0;

                        if ((a).TabIndex < 100 && (a).TabIndex > 0)
                        {
                            (a).TabIndex += 100;
                            (a).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");
                        }
                        if ((b).TabIndex < 100 && (b).TabIndex > 0)
                        {
                            (b).TabIndex += 100;
                            (b).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");
                        }
                    }
                    a = ((ImageButton)sender);

                }
                if (k == 1)
                {
                    b = ((ImageButton)sender);

                    if (a.TabIndex == b.TabIndex)
                    {

                        a.TabIndex = -1;
                        b.TabIndex = -1;
                        par34 += 1;
                        if (par34 == 6)
                        {
                            Button_couple_3x4_retry.Text = "Retry";//Inf.Text = "You Win";
                        }
                    }

                }

                k++;
                Inf.Text = par34.ToString();
            }
        }
    }
}