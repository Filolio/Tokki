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
    public partial class Cauple_4x5 : ContentPage
    {
        int[] indexes_3x4 = { 2, 2, 2, 2, 2, 2 };
        int[] indexes_4x5 = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        int c;
        int k;
        int par45;
        ImageButton a;
        ImageButton b;
        public Cauple_4x5()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;

            new_game_couple_4x5();
        }

        private void new_game_couple_4x5()
        {
            k = 0;
            par45 = 0;
            Button_couple_4x5_retry.Text = "Give up";
            scard00.TabIndex = game_couple_4x5_getindex();
            scard01.TabIndex = game_couple_4x5_getindex();
            scard02.TabIndex = game_couple_4x5_getindex();
            scard03.TabIndex = game_couple_4x5_getindex();
            scard04.TabIndex = game_couple_4x5_getindex();

            scard10.TabIndex = game_couple_4x5_getindex();
            scard11.TabIndex = game_couple_4x5_getindex();
            scard12.TabIndex = game_couple_4x5_getindex();
            scard13.TabIndex = game_couple_4x5_getindex();
            scard14.TabIndex = game_couple_4x5_getindex();

            scard20.TabIndex = game_couple_4x5_getindex();
            scard21.TabIndex = game_couple_4x5_getindex();
            scard22.TabIndex = game_couple_4x5_getindex();
            scard23.TabIndex = game_couple_4x5_getindex();
            scard24.TabIndex = game_couple_4x5_getindex();

            scard30.TabIndex = game_couple_4x5_getindex();
            scard31.TabIndex = game_couple_4x5_getindex();
            scard32.TabIndex = game_couple_4x5_getindex();
            scard33.TabIndex = game_couple_4x5_getindex();
            scard34.TabIndex = game_couple_4x5_getindex();


            for (int i = 0; i < 10; i++)
            {
                indexes_4x5[i] = 2;
            }
            game_couple_4x5_closeall();
            Stack_game_couple_4x5.IsVisible = true;
        }
        private void game_couple_4x5_Click(object sender, EventArgs e)
        {
            new_game_couple_4x5();
        }


        private int game_couple_4x5_getindex()
        {
            var rand = new Random();
            while (true)
            {
                c = rand.Next(1, 11);
                if (indexes_4x5[c - 1] > 0)
                {
                    indexes_4x5[c - 1]--;
                    break;
                }
            }
            return c;
        }

        private void game_couple_4x5_closeall()
        {
            (scard00).TabIndex += 100;
            (scard00).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard01).TabIndex += 100;
            (scard01).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard02).TabIndex += 100;
            (scard02).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard03).TabIndex += 100;
            (scard03).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard04).TabIndex += 100;
            (scard04).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");


            (scard10).TabIndex += 100;
            (scard10).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard11).TabIndex += 100;
            (scard11).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard12).TabIndex += 100;
            (scard12).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard13).TabIndex += 100;
            (scard13).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard14).TabIndex += 100;
            (scard14).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");


            (scard20).TabIndex += 100;
            (scard20).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard21).TabIndex += 100;
            (scard21).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard22).TabIndex += 100;
            (scard22).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard23).TabIndex += 100;
            (scard23).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard24).TabIndex += 100;
            (scard24).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");


            (scard30).TabIndex += 100;
            (scard30).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard31).TabIndex += 100;
            (scard31).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard32).TabIndex += 100;
            (scard32).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard33).TabIndex += 100;
            (scard33).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");

            (scard34).TabIndex += 100;
            (scard34).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + 0.ToString() + ".jpg");
        }

        private void game_couple_4x5_field_Click(object sender, EventArgs e)
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
                        par45 += 1;
                        if (par45 == 10)
                        {
                            Button_couple_4x5_retry.Text = "Retry";//Inf.Text = "You Win";
                        }
                    }


                }

                k++;
            }
        }
    }
}
