using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Tokki.MainPage;

namespace Tokki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hue_5x5 : ContentPage
    {
        Hcolor[,] hue_orig_colors_5x5 = new Hcolor[5, 5];
        Hcolor[,] hue_game_colors_5x5 = new Hcolor[5, 5];
        Button[,] hue_game_5x5_bottons = new Button[5, 5];
        double saturat = 0.55;
        double hu = 0.15;
        int pair_not_right = 0;
        Button acl = new Button();
        Button bcl = new Button();
        int k = 0;
        public Hue_5x5()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;

            new_game_hue_5x5();
        }
        private void game_hue_5x5_Click(object sender, EventArgs e)
        {
            new_game_hue_5x5();
        }

        private void new_game_hue_5x5(){
            arrinf.Text = " yes ";
            Stack_game_hue_5x5.IsVisible = true;
            gencornercolor_5x5();
            gengrad_5x5(new coordforgrad(0, 0), new coordforgrad(4, 0), new coordforgrad(0, 4), new coordforgrad(4, 4));
            copycolors_5x5();
            showgrad_5x5();
            pair_not_right = 0;
        }

        public class Hcolor
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

        private void gencornercolor_5x5()
        {
            var rand = new Random();

            double rand_color_h = new double();

            rand_color_h = ((double)rand.Next(0, 100)) / 100;
            Color rand_color_rgb = new Color();
            rand_color_rgb = Color.FromHsv((((rand_color_h) * 100) % 100) / 100, saturat, 1);

            hue_orig_colors_5x5[0, 0] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h + hu) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_5x5[4, 0] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h + hu * 2) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_5x5[0, 4] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            rand_color_rgb = Color.FromHsv((((rand_color_h + hu * 3) * 100) % 100) / 100, saturat, 1);
            hue_orig_colors_5x5[4, 4] = new Hcolor(rand_color_rgb.R, rand_color_rgb.G, rand_color_rgb.B);
            //hue_orig_colors_5x5[3, 3] = tt;
            Grid_hue_5x5.Children.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    hue_game_5x5_bottons[i, j] = new Button();
                    hue_game_5x5_bottons[i, j].BorderColor = Color.White;
                    hue_game_5x5_bottons[i, j].TabIndex = i * 10 + j;
                    hue_game_5x5_bottons[i, j].CornerRadius = 0;
                    if (!(!((i == 4) && (j == 4)) && (!((i == 0) && (j == 4))) && (!((i == 0) && (j == 0))) && (!((i == 4) && (j == 0))) && (!((i == 2) && (j == 2)))))

                    {
                        hue_game_5x5_bottons[i, j].Text = "●";
                        hue_game_5x5_bottons[i, j].TextColor = Color.Black;


                    }
                    else hue_game_5x5_bottons[i, j].Clicked += game_hue_5x5_field_Click;
                    Grid_hue_5x5.Children.Add(hue_game_5x5_bottons[i, j], i, j);
                }
            }

        }

        private Hcolor getavecolor_5x5(coordforgrad lu, coordforgrad ru, coordforgrad ld, coordforgrad rd)
        {

            return new Hcolor((hue_orig_colors_5x5[lu.x, lu.y].r + hue_orig_colors_5x5[ru.x, ru.y].r + hue_orig_colors_5x5[ld.x, ld.y].r + hue_orig_colors_5x5[rd.x, rd.y].r) / 4,
                              (hue_orig_colors_5x5[lu.x, lu.y].g + hue_orig_colors_5x5[ru.x, ru.y].g + hue_orig_colors_5x5[ld.x, ld.y].g + hue_orig_colors_5x5[rd.x, rd.y].g) / 4,
                              (hue_orig_colors_5x5[lu.x, lu.y].b + hue_orig_colors_5x5[ru.x, ru.y].b + hue_orig_colors_5x5[ld.x, ld.y].b + hue_orig_colors_5x5[rd.x, rd.y].b) / 4);

        }

        private Hcolor getavecolor_5x5(coordforgrad f, coordforgrad s)
        {
            return new Hcolor((hue_orig_colors_5x5[f.x, f.y].r + hue_orig_colors_5x5[s.x, s.y].r) / 2,
                              (hue_orig_colors_5x5[f.x, f.y].g + hue_orig_colors_5x5[s.x, s.y].g) / 2,
                              (hue_orig_colors_5x5[f.x, f.y].b + hue_orig_colors_5x5[s.x, s.y].b) / 2
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

        private void copycolors_5x5()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {


                    hue_game_colors_5x5[i, j] = hue_orig_colors_5x5[i, j];

                }

            }
        }

        private void genrandgrad_5x5()
        {

            var rand = new Random();
            int kx;
            int ky;
            int lx;
            int ly;
            int swap_count = 0;
            while (swap_count < 6)
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
                        Hcolor temp = hue_game_colors_5x5[kx, ky];
                        hue_game_colors_5x5[kx, ky] = hue_game_colors_5x5[lx, ly];
                        hue_game_colors_5x5[lx, ly] = temp;
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
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).BorderWidth = 0;
                    hue_game_5x5_bottons[i, j].BorderWidth = 0;
                    hue_game_5x5_bottons[i, j].BackgroundColor = Color.FromRgb(hue_game_colors_5x5[i, j].r, hue_game_colors_5x5[i, j].g, hue_game_colors_5x5[i, j].b);
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).BackgroundColor = Color.FromRgb(hue_game_colors_5x5[i, j].r, hue_game_colors_5x5[i, j].g, hue_game_colors_5x5[i, j].b);
                }

            }
        }


        private bool is_hue_completed_5x5()
        {
            pair_not_right=0;
            bool is_hue_completed = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hue_game_colors_5x5[i, j] != hue_orig_colors_5x5[i, j]) { 
                    is_hue_completed = false;

                        pair_not_right++;
                    }
                }

            }
            return is_hue_completed;

        }

        private void game_hue_5x5_field_Click(object sender, EventArgs e)
        {
            //scolor00.BackgroundColor = Color.FromRgb(0,0,0); 

            ((Button)sender).BorderWidth = 5;
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
                hue_game_colors_5x5[(acl.TabIndex) / 10, (acl.TabIndex) % 10] = hue_game_colors_5x5[(bcl.TabIndex) / 10, (bcl.TabIndex) % 10];
                hue_game_colors_5x5[(bcl.TabIndex) / 10, (bcl.TabIndex) % 10] = temp;
                showgrad_5x5();
                //arrinf.Text = String.Format("{0} ", is_hue_completed());
                if (is_hue_completed_5x5())

                    arrinf.Text = " yes ";

                else arrinf.Text = pair_not_right.ToString();


            }
            //}

            //game_couple_enable(true);


        }

        private void Button_hue_5x5_gradrand_Clicked(object sender, EventArgs e)
        {
            genrandgrad_5x5();
            is_hue_completed_5x5();
            arrinf.Text = pair_not_right.ToString();
            showgrad_5x5();
        }

        private void Button_hue_5x5_tip_Clicked(object sender, EventArgs e)
        {
            Hcolor tipcl = new Hcolor();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hue_game_colors_5x5[i, j] != hue_orig_colors_5x5[i, j])
                    {
                        hue_game_5x5_bottons[i, j].BorderWidth = 10;
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
                        hue_game_5x5_bottons[i, j].BorderWidth = 10;

                        return;

                    }
                }
            }
        }
    }
}