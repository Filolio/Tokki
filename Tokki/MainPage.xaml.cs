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
        /*bool game_brearth_started = false;
        int breath_mode = 0;
        int counter = 1;
        int counter_ms = 1;
        int t_5min = 304;
        int t_10min = 608;
        int t_15min = 912;*/

        public MainPage()
        {
            InitializeComponent();

            //card00.Source = ImageSource.FromResource("rol_sec.pictures.couple.card" +0.ToString() + ".jpg");
            // image_background.Source = ImageSource.FromResource("rol_sec.background.jpg");
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;


           /* Device.StartTimer(TimeSpan.FromSeconds(1), () =>
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

            });*/
        }
       /* public void Breath_timer()
        {
            int sec;
            int min;
            int br = 19;
            int t_min;
            switch (breath_mode)
            {
                case 1:
                    t_min = t_5min;
                    break;
                case 2:
                    t_min = t_10min;
                    break;
                case 3:
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

                if ((t_5min - counter) % br < 19) label_breath.Text = "inhale";
                if ((t_5min - counter) % br < 15) label_breath.Text = "holding";
                if ((t_5min - counter) % br < 8) label_breath.Text = "exhale";
                //inf.Text=( (t_5min - counter) % 19).ToString();
            }

            //label_Breath_5_sec.Text=DateTime.Now.Second.ToString();
        }*/

        private async void game_breath_Click(object sender, EventArgs e)
        {
            //Stack_main_menu.IsVisible = false;
            await Navigation.PushAsync(new Menu_Breath());
           /* Stack_game_breath.IsVisible = true;
            Stack_game_breath_5.IsVisible = false;
            game_brearth_started = false;*/
        }
        private async void game_couple_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu_Cauple());
            /*Stack_main_menu.IsVisible = false;
            Stack_game_couple.IsVisible = true;
            Stack_game_couple_3x4.IsVisible = false;
            Stack_game_couple_4x5.IsVisible = false;*/
            //Stack_game_breath_5.IsVisible = false;
            //f = false;
        }
        private async void game_hue_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu_Hue());
           /* Stack_main_menu.IsVisible = false;
            Stack_game_hue.IsVisible = true;
            //Stack_game_couple_3x4.IsVisible = false;
            Stack_game_hue_5x5.IsVisible = false;
            Stack_game_hue_9x9.IsVisible = false;*/
            //Stack_game_breath_5.IsVisible = false;
            //f = false;
        }
        private void goto_mainmenu_Click(object sender, EventArgs e)
        {

            Stack_main_menu.IsVisible = true;
            //Stack_game_breath.IsVisible = false;
            Stack_game_couple.IsVisible = false;
            //Stack_game_hue.IsVisible = false;

        }

       /* private void game_breath_5_Click(object sender, EventArgs e)
        {
            // main_menu.
            Stack_game_breath.IsVisible = false;
            Stack_game_breath_5.IsVisible = true;
            label_Breath_5_min.Text = "5";
            label_Breath_5_sec.Text = "04";
            breath_mode = 1;
        }

        private void Button_Breath_5_start_Click(object sender, EventArgs e)
        {

            game_brearth_started = !game_brearth_started;
            counter = 0;
            if (game_brearth_started) Button_Breath_5_start.Text = "Stop";
            else Button_Breath_5_start.Text = "Start";



        }

        private void game_breath_10_Click(object sender, EventArgs e)
        {
            Stack_game_breath.IsVisible = false;
            Stack_game_breath_5.IsVisible = true;
            label_Breath_5_min.Text = "10";
            label_Breath_5_sec.Text = "08";
            breath_mode = 2;
        }

        private void game_breath_15_Click(object sender, EventArgs e)
        {
            Stack_game_breath.IsVisible = false;
            Stack_game_breath_5.IsVisible = true;
            label_Breath_5_min.Text = "15";
            label_Breath_5_sec.Text = "12";
            breath_mode = 3;
        }*/

        int[] indexes_3x4 = { 2, 2, 2, 2, 2, 2 };
        int[] indexes_4x5 = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        int c;
        private void game_couple_3x4_Click(object sender, EventArgs e)
        {
            // counter = 10;
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
            Stack_game_couple.IsVisible = false;
            Stack_game_couple_3x4.IsVisible = true;
        }
        private void game_couple_4x5_Click(object sender, EventArgs e)
        {
            //counter = 10;
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
            Stack_game_couple.IsVisible = false;
            Stack_game_couple_4x5.IsVisible = true;
        }
       /* private void game_hue_5x5_Click(object sender, EventArgs e)
        {
            arrinf.Text = " yes ";
            Stack_game_hue.IsVisible = false;
            Stack_game_hue_5x5.IsVisible = true;
            gencornercolor_5x5();
            gengrad_5x5(new coordforgrad(0, 0), new coordforgrad(4, 0), new coordforgrad(0, 4), new coordforgrad(4, 4));
            copycolors_5x5();
            showgrad_5x5();
        }
        private void game_hue_9x9_Click(object sender, EventArgs e)
        {
            arrinf_9x9.Text = " yes ";
            Stack_game_hue.IsVisible = false;
            Stack_game_hue_9x9.IsVisible = true;
            gencornercolor_9x9();
            gengrad_9x9(new coordforgrad(0, 0), new coordforgrad(8, 0), new coordforgrad(0, 8), new coordforgrad(8, 8));
            copycolors_9x9();
            showgrad_9x9();
        }*/
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
        ImageButton a;
        ImageButton b;
        int k = 0;
        int par34 = 0;

        private void game_couple_3x4_field_Click(object sender, EventArgs e)
        {
            //game_couple_enable(false);
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
            //game_couple_enable(true);
        }
        int par45 = 0;
        private void game_couple_4x5_field_Click(object sender, EventArgs e)
        {
            //game_couple_enable(false);
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

            //game_couple_enable(true);
        }
       /* public class Hcolor
        {

            public double r;
            public double g;
            public double b;
            public Hcolor(double r, double g, double b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
            public Hcolor() { }
        }
        public class coordforgrad
        {

            public int x;
            public int y;
            public coordforgrad(int x, int y)
            {
                this.x = x;
                this.y = y;
            }


        }
        //Hcolor[,] hue_orig_colors_5x5 = new Hcolor[5, 5];
        
        Hcolor[,] hue_orig_colors_5x5 = new Hcolor[5, 5];
        Hcolor[,] hue_game_colors_5x5 = new Hcolor[5, 5];
        Button[,] hue_game_5x5_bottons = new Button[5, 5];
        Hcolor[,] hue_orig_colors_9x9 = new Hcolor[9, 9];
        Hcolor[,] hue_game_colors_9x9 = new Hcolor[9, 9];
        Button[,] hue_game_9x9_bottons = new Button[9, 9];
        double saturat=0.55;
        double hu = 0.15;

        private void gencornercolor_5x5()
        {
            var rand = new Random();

            double rand_color_h= new double();

            rand_color_h = ((double)rand.Next(0, 100)) / 100;
            Color rand_color_rgb = new Color();
            rand_color_rgb = Color.FromHsv((((rand_color_h) * 100) % 100) / 100, saturat , 1);

            hue_orig_colors_5x5[0, 0] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h+hu) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_5x5[4, 0] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h+hu*2) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_5x5[0, 4] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h+hu*3) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_5x5[4, 4] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            //hue_orig_colors_5x5[3, 3] = tt;
            Grid_hue_5x5.Children.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    hue_game_5x5_bottons[i, j] = new Button();
                    hue_game_5x5_bottons[i, j].TabIndex = i * 10 + j;
                    hue_game_5x5_bottons[i, j].CornerRadius = 0;
                    if (!(!((i == 4) && (j == 4)) && (!((i == 0) && (j == 4))) && (!((i == 0) && (j == 0))) && (!((i == 4) && (j == 0))) && (!((i == 2) && (j == 2)))))
                       
                        {
                        hue_game_5x5_bottons[i, j].Text = "●";
                        hue_game_5x5_bottons[i, j].TextColor = Color.Black;

                       
                        } else hue_game_5x5_bottons[i, j].Clicked += game_hue_5x5_field_Click;
                            Grid_hue_5x5.Children.Add(hue_game_5x5_bottons[i, j], i, j);
                }
            }

        }
        private void gencornercolor_9x9()
        {
            var rand = new Random();

            double rand_color_h = new double();

            rand_color_h = ((double)rand.Next(0, 100)) / 100;
            Color rand_color_rgb = new Color();
            rand_color_rgb = Color.FromHsv((((rand_color_h) * 100) % 100) / 100, saturat, 1);

            hue_orig_colors_9x9[0, 0] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h + hu) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_9x9[8, 0] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h + hu * 2) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_9x9[0, 8] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h + hu * 3) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_9x9[8, 8] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            Grid_hue_9x9.Children.Clear();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    hue_game_9x9_bottons[i, j] = new Button();
                    hue_game_9x9_bottons[i, j].TabIndex = i * 10 + j;
                    hue_game_9x9_bottons[i, j].CornerRadius = 0;
                    if (!(!((i == 8) && (j == 8)) && (!((i == 0) && (j == 8))) && (!((i == 0) && (j == 0))) && (!((i == 8) && (j == 0))) && (!((i == 4) && (j == 4)))))

                    {
                        hue_game_9x9_bottons[i, j].Text = "●";
                        hue_game_9x9_bottons[i, j].TextColor = Color.Black;


                    }
                    else hue_game_9x9_bottons[i, j].Clicked += game_hue_9x9_field_Click;
                    Grid_hue_9x9.Children.Add(hue_game_9x9_bottons[i, j], i, j);
                }
            }

        }
        private Hcolor getavecolor_5x5(coordforgrad lu, coordforgrad ru, coordforgrad ld, coordforgrad rd)
        {

            return new Hcolor((hue_orig_colors_5x5[lu.x, lu.y].r + hue_orig_colors_5x5[ru.x, ru.y].r + hue_orig_colors_5x5[ld.x, ld.y].r + hue_orig_colors_5x5[rd.x, rd.y].r) / 4,
                              (hue_orig_colors_5x5[lu.x, lu.y].g + hue_orig_colors_5x5[ru.x, ru.y].g + hue_orig_colors_5x5[ld.x, ld.y].g + hue_orig_colors_5x5[rd.x, rd.y].g) / 4,
                              (hue_orig_colors_5x5[lu.x, lu.y].b + hue_orig_colors_5x5[ru.x, ru.y].b + hue_orig_colors_5x5[ld.x, ld.y].b + hue_orig_colors_5x5[rd.x, rd.y].b) / 4);

        }
        private Hcolor getavecolor_9x9(coordforgrad lu, coordforgrad ru, coordforgrad ld, coordforgrad rd)
        {

            return new Hcolor((hue_orig_colors_9x9[lu.x, lu.y].r + hue_orig_colors_9x9[ru.x, ru.y].r + hue_orig_colors_9x9[ld.x, ld.y].r + hue_orig_colors_9x9[rd.x, rd.y].r) / 4,
                              (hue_orig_colors_9x9[lu.x, lu.y].g + hue_orig_colors_9x9[ru.x, ru.y].g + hue_orig_colors_9x9[ld.x, ld.y].g + hue_orig_colors_9x9[rd.x, rd.y].g) / 4,
                              (hue_orig_colors_9x9[lu.x, lu.y].b + hue_orig_colors_9x9[ru.x, ru.y].b + hue_orig_colors_9x9[ld.x, ld.y].b + hue_orig_colors_9x9[rd.x, rd.y].b) / 4);

        }
        private Hcolor getavecolor_5x5(coordforgrad f, coordforgrad s)
        {
            return new Hcolor((hue_orig_colors_5x5[f.x, f.y].r + hue_orig_colors_5x5[s.x, s.y].r) / 2,
                              (hue_orig_colors_5x5[f.x, f.y].g + hue_orig_colors_5x5[s.x, s.y].g) / 2,
                              (hue_orig_colors_5x5[f.x, f.y].b + hue_orig_colors_5x5[s.x, s.y].b) / 2
                );
        }
        private Hcolor getavecolor_9x9(coordforgrad f, coordforgrad s)
        {
            return new Hcolor((hue_orig_colors_9x9[f.x, f.y].r + hue_orig_colors_9x9[s.x, s.y].r) / 2,
                              (hue_orig_colors_9x9[f.x, f.y].g + hue_orig_colors_9x9[s.x, s.y].g) / 2,
                              (hue_orig_colors_9x9[f.x, f.y].b + hue_orig_colors_9x9[s.x, s.y].b) / 2
                );
        }
        
        private void gengrad_5x5(coordforgrad lu, coordforgrad ru, coordforgrad ld, coordforgrad rd)
        {
            //hue_orig_colors_5x5inf.Text += String.Format("[({0},{1}) ({2},{3}) ({4},{5}) ({6},{7}) {8}]", lu.x, lu.y, ru.x ,ru.y, ld.x , ld.y, rd.x , rd.y, gl);
            if ((lu.x + ru.x) % 2 == 0 || (lu.y + ld.y) % 2 == 0 || (ru.y + rd.y % 2) == 0 || (ld.x + rd.x) % 2 == 0)
            {
                
                //hue_orig_colors_5x5inf.Text += String.Format("yes \n");
                hue_orig_colors_5x5[(lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4] = getavecolor_5x5(lu, ru, ld, rd);
                hue_orig_colors_5x5[(lu.x + ru.x) / 2, (lu.y + ru.y) / 2] = getavecolor_5x5(lu, ru);
                hue_orig_colors_5x5[(ld.x + lu.x) / 2, (ld.y + lu.y) / 2] = getavecolor_5x5(ld, lu);
                hue_orig_colors_5x5[(ru.x + rd.x) / 2, (ru.y + rd.y) / 2] = getavecolor_5x5(ru, rd);
                hue_orig_colors_5x5[(ld.x + rd.x) / 2, (ld.y + rd.y) / 2] = getavecolor_5x5(ld, rd);
                gengrad_5x5(lu, new coordforgrad((lu.x + ru.x) / 2, (lu.y + ru.y) / 2), new coordforgrad((ld.x + lu.x) / 2, (ld.y + lu.y) / 2), new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4));
                gengrad_5x5(new coordforgrad((lu.x + ru.x) / 2, (lu.y + ru.y) / 2), ru, new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4), new coordforgrad((ru.x + rd.x) / 2, (ru.y + rd.y) / 2));
                gengrad_5x5(new coordforgrad((ld.x + lu.x) / 2, (ld.y + lu.y) / 2), new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4), ld, new coordforgrad((ld.x + rd.x) / 2, (ld.y + rd.y) / 2));
                gengrad_5x5(new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4), new coordforgrad((ru.x + rd.x) / 2, (ru.y + rd.y) / 2), new coordforgrad((ld.x + rd.x) / 2, (ld.y + rd.y) / 2), rd);
            }

            //hue_orig_colors_5x5inf.Text += String.Format("no \n");


        }
        private void gengrad_9x9(coordforgrad lu, coordforgrad ru, coordforgrad ld, coordforgrad rd)
        {
            //hue_orig_colors_5x5inf.Text += String.Format("[({0},{1}) ({2},{3}) ({4},{5}) ({6},{7}) {8}]", lu.x, lu.y, ru.x ,ru.y, ld.x , ld.y, rd.x , rd.y, gl);
            if ((lu.x + ru.x) % 2 == 0 || (lu.y + ld.y) % 2 == 0 || (ru.y + rd.y % 2) == 0 || (ld.x + rd.x) % 2 == 0)
            {
                
                //hue_orig_colors_5x5inf.Text += String.Format("yes \n");
                hue_orig_colors_9x9[(lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4] = getavecolor_9x9(lu, ru, ld, rd);
                hue_orig_colors_9x9[(lu.x + ru.x) / 2, (lu.y + ru.y) / 2] = getavecolor_9x9(lu, ru);
                hue_orig_colors_9x9[(ld.x + lu.x) / 2, (ld.y + lu.y) / 2] = getavecolor_9x9(ld, lu);
                hue_orig_colors_9x9[(ru.x + rd.x) / 2, (ru.y + rd.y) / 2] = getavecolor_9x9(ru, rd);
                hue_orig_colors_9x9[(ld.x + rd.x) / 2, (ld.y + rd.y) / 2] = getavecolor_9x9(ld, rd);
                gengrad_9x9(lu, new coordforgrad((lu.x + ru.x) / 2, (lu.y + ru.y) / 2), new coordforgrad((ld.x + lu.x) / 2, (ld.y + lu.y) / 2), new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4));
                gengrad_9x9(new coordforgrad((lu.x + ru.x) / 2, (lu.y + ru.y) / 2), ru, new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4), new coordforgrad((ru.x + rd.x) / 2, (ru.y + rd.y) / 2));
                gengrad_9x9(new coordforgrad((ld.x + lu.x) / 2, (ld.y + lu.y) / 2), new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4), ld, new coordforgrad((ld.x + rd.x) / 2, (ld.y + rd.y) / 2));
                gengrad_9x9(new coordforgrad((lu.x + ru.x + ld.x + rd.x) / 4, (lu.y + ru.y + ld.y + rd.y) / 4), new coordforgrad((ru.x + rd.x) / 2, (ru.y + rd.y) / 2), new coordforgrad((ld.x + rd.x) / 2, (ld.y + rd.y) / 2), rd);
            }

            //hue_orig_colors_5x5inf.Text += String.Format("no \n");


        }
        private void copycolors_5x5() {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {


                    hue_game_colors_5x5[i, j] = hue_orig_colors_5x5[i, j];

                }

            }
        }
        private void copycolors_9x9()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {


                    hue_game_colors_9x9[i, j] = hue_orig_colors_9x9[i, j];

                }

            }
        }
        private void genrandgrad_5x5() {
            
            var rand = new Random();
            int kx;
            int ky;
            int lx;
            int ly;
            int swap_count = 0;
            while (swap_count<6)
            {
                kx = rand.Next(0, 5);
                ky = rand.Next(0, 5);
                lx = rand.Next(0, 5);
                ly = rand.Next(0, 5);
                //arrinf.Text += String.Format("({0} {1}),({2},{3}) \n", kx, ky, lx, ly);
                if (!((kx == 4) && (ky == 4)) && (!((kx == 0) && (ky == 4))) && (!((kx == 0) && (ky == 0))) && (!((kx == 4) && (ky == 0))) && (!((kx == 2) && (ky == 2))))
                if (!((lx == 4) && (ly == 4)) && (!((lx == 0) && (ly == 4))) && (!((lx == 0) && (ly == 0))) && (!((lx == 4) && (ly == 0))) && (!((lx == 2) && (ly == 2))))
                {
                    //arrinf.Text += "+";
                Hcolor temp = hue_game_colors_5x5[kx,ky];
                hue_game_colors_5x5[kx, ky] = hue_game_colors_5x5[lx,ly];
                hue_game_colors_5x5[lx,ly] = temp;
                swap_count++;
                }

            }
        }
        private void genrandgrad_9x9()
        {

            var rand = new Random();
            int kx;
            int ky;
            int lx;
            int ly;
            int swap_count = 0;
            while (swap_count < 16)
            {
                kx = rand.Next(0, 9);
                ky = rand.Next(0, 9);
                lx = rand.Next(0, 9);
                ly = rand.Next(0, 9);
                //arrinf.Text += String.Format("({0} {1}),({2},{3}) \n", kx, ky, lx, ly);
                if (    !((kx == 8) && (ky == 8)) && (!((kx == 0) && (ky == 8))) && (!((kx == 0) && (ky == 0))) && (!((kx == 8) && (ky == 0))) && (!((kx == 4) && (ky == 4))))
                    if (!((lx == 8) && (ly == 8)) && (!((lx == 0) && (ly == 8))) && (!((lx == 0) && (ly == 0))) && (!((lx == 8) && (ly == 0))) && (!((lx == 4) && (ly == 4))))
                    {
                        //arrinf.Text += "+";
                        Hcolor temp = hue_game_colors_9x9[kx, ky];
                        hue_game_colors_9x9[kx, ky] = hue_game_colors_9x9[lx, ly];
                        hue_game_colors_9x9[lx, ly] = temp;
                        swap_count++;
                    }

            }
        }
        private void showgrad_5x5()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //hue_orig_colors_5x5[i, j]= tt;
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).Margin = 0;
                    hue_game_5x5_bottons[i, j].Margin = 0;
                    hue_game_5x5_bottons[i, j].BackgroundColor= Color.FromRgb(hue_game_colors_5x5[i, j].r, hue_game_colors_5x5[i, j].g, hue_game_colors_5x5[i, j].b);
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).BackgroundColor = Color.FromRgb(hue_game_colors_5x5[i, j].r, hue_game_colors_5x5[i, j].g, hue_game_colors_5x5[i, j].b);
                }

            }
        }
        private void showgrad_9x9()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //hue_orig_colors_5x5[i, j]= tt;
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).Margin = 0;
                    hue_game_9x9_bottons[i, j].Margin = 0;
                    hue_game_9x9_bottons[i, j].BackgroundColor = Color.FromRgb(hue_game_colors_9x9[i, j].r, hue_game_colors_9x9[i, j].g, hue_game_colors_9x9[i, j].b);
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).BackgroundColor = Color.FromRgb(hue_game_colors_5x5[i, j].r, hue_game_colors_5x5[i, j].g, hue_game_colors_5x5[i, j].b);
                }

            }
           
        }
        Button acl = new Button();
        Button bcl = new Button();
        private bool is_hue_completed_5x5() {

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hue_game_colors_5x5[i, j] != hue_orig_colors_5x5[i, j]) return false;
                }

            }
            return true;
        
        }
        private bool is_hue_completed_9x9()
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (hue_game_colors_9x9[i, j] != hue_orig_colors_9x9[i, j]) return false;
                }

            }
            return true;

        }
        private void game_hue_5x5_field_Click(object sender, EventArgs e){
            //scolor00.BackgroundColor = Color.FromRgb(0,0,0); 

            ((Button)sender).Margin = 5;
                //game_couple_enable(false);
                // if (((Button)sender).TabIndex > 100)
                //{
                //((ImageButton)sender).TabIndex -= 100;
                //((ImageButton)sender).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + ((ImageButton)sender).TabIndex.ToString() + ".jpg");
                    if (k == 0)
                    {
                        acl = ((Button)sender);
                    }
                    if (k == 1)
                    {
                        bcl = ((Button)sender);
                    }
                    k++;
                        if (k == 2)
                        {
                            k = 0;
                        Hcolor temp = hue_game_colors_5x5[(acl.TabIndex) / 10, (acl.TabIndex) % 10];
                        hue_game_colors_5x5[(acl.TabIndex)/10,(acl.TabIndex)%10] = hue_game_colors_5x5[(bcl.TabIndex) / 10,(bcl.TabIndex) % 10];
                        hue_game_colors_5x5[(bcl.TabIndex) / 10, (bcl.TabIndex) % 10] = temp;
                        showgrad_5x5();
                //arrinf.Text = String.Format("{0} ", is_hue_completed());
                if (is_hue_completed_5x5())
                
                    arrinf.Text = " yes ";
                
                else arrinf.Text = " no ";


                        }
                //}

                //game_couple_enable(true);

            
        }
        private void game_hue_9x9_field_Click(object sender, EventArgs e)
        {
            //scolor00.BackgroundColor = Color.FromRgb(0,0,0); 

            ((Button)sender).Margin = 4;
            //game_couple_enable(false);
            // if (((Button)sender).TabIndex > 100)
            //{
            //((ImageButton)sender).TabIndex -= 100;
            //((ImageButton)sender).Source = ImageSource.FromResource("Tokki.pictures.couple.card" + ((ImageButton)sender).TabIndex.ToString() + ".jpg");
            if (k == 0)
            {
                acl = ((Button)sender);
            }
            if (k == 1)
            {
                bcl = ((Button)sender);
            }
            k++;
            if (k == 2)
            {
                k = 0;
                Hcolor temp = hue_game_colors_9x9[(acl.TabIndex) / 10, (acl.TabIndex) % 10];
                hue_game_colors_9x9[(acl.TabIndex) / 10, (acl.TabIndex) % 10] = hue_game_colors_9x9[(bcl.TabIndex) / 10, (bcl.TabIndex) % 10];
                hue_game_colors_9x9[(bcl.TabIndex) / 10, (bcl.TabIndex) % 10] = temp;
                showgrad_9x9();
                //arrinf.Text = String.Format("{0} ", is_hue_completed());
                if (is_hue_completed_9x9())

                    arrinf_9x9.Text = " yes ";

                else arrinf_9x9.Text = " no ";


            }
            //}

            //game_couple_enable(true);


        }
        private void Button_hue_5x5_gradrand_Clicked(object sender, EventArgs e)
        {
            genrandgrad_5x5();
            arrinf.Text = " no ";
            showgrad_5x5();
        }
        private void Button_hue_9x9_gradrand_Clicked(object sender, EventArgs e)
        {
            genrandgrad_9x9();
            arrinf_9x9.Text = " no ";
            showgrad_9x9();
        }
        private void Button_hue_5x5_tip_Clicked(object sender, EventArgs e)
        {
            //genrandgrad();
            //arrinf.Text = " no ";
            //showgrad();
            Hcolor tipcl= new Hcolor();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hue_game_colors_5x5[i, j] != hue_orig_colors_5x5[i, j]) {
                        hue_game_5x5_bottons[i, j].Margin = 10;
                        tipcl = hue_orig_colors_5x5[i, j];
                        goto LoopEnd;
                        
                    
                    }
                }
            }
            LoopEnd:
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hue_game_colors_5x5[i, j] == tipcl)
                    {
                        hue_game_5x5_bottons[i, j].Margin = 10;

                        return;

                    }
                }
            }
        }
        private void Button_hue_9x9_tip_Clicked(object sender, EventArgs e)
        {
            //genrandgrad();
            //arrinf.Text = " no ";
            //showgrad();
            Hcolor tipcl = new Hcolor();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (hue_game_colors_9x9[i, j] != hue_orig_colors_9x9[i, j])
                    {
                        hue_game_9x9_bottons[i, j].Margin = 6;
                        tipcl = hue_orig_colors_9x9[i, j];
                        goto LoopEnd;


                    }
                }
            }
        LoopEnd:
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (hue_game_colors_9x9[i, j] == tipcl)
                    {
                        hue_game_9x9_bottons[i, j].Margin = 6;

                        return;

                    }
                }
            }
        }
        private void slider_s_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            saturat = e.NewValue;
        }
        private void slider_h_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            hu = e.NewValue;
        }*/
    }
}
