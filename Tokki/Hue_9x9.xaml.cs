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
    public partial class Hue_9x9 : ContentPage
    {
        Hcolor[,] hue_orig_colors_9x9 = new Hcolor[9, 9];
        Hcolor[,] hue_game_colors_9x9 = new Hcolor[9, 9];
        Button[,] hue_game_9x9_bottons = new Button[9, 9];
        double saturat = 0.55;
        double hu = 0.15;
        int pair_not_right = 0;
        Button acl = new Button();
        Button bcl = new Button();
        int k = 0;
        public Hue_9x9()
        {
            InitializeComponent();
            Image_background.Source = ImageSource.FromResource("Tokki.pictures.background_menu_bord.png");
            Image_background.Aspect = Aspect.Fill;

            new_game_hue_9x9();
        }

       private void game_hue_9x9_Click(object sender, EventArgs e)
        {
            new_game_hue_9x9();
        }
       private void new_game_hue_9x9()
        {
            arrinf_9x9.Text = "yes";
            Stack_game_hue_9x9.IsVisible = true;
            gencornercolor_9x9();
            gengrad_9x9(new coordforgrad(0, 0), new coordforgrad(8, 0), new coordforgrad(0, 8), new coordforgrad(8, 8));
            copycolors_9x9();
            showgrad_9x9();
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
                    hue_game_9x9_bottons[i, j].BorderColor = Color.White;
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
        private Hcolor getavecolor_9x9(coordforgrad lu, coordforgrad ru, coordforgrad ld, coordforgrad rd)
        {

            return new Hcolor((hue_orig_colors_9x9[lu.x, lu.y].r + hue_orig_colors_9x9[ru.x, ru.y].r + hue_orig_colors_9x9[ld.x, ld.y].r + hue_orig_colors_9x9[rd.x, rd.y].r) / 4,
                              (hue_orig_colors_9x9[lu.x, lu.y].g + hue_orig_colors_9x9[ru.x, ru.y].g + hue_orig_colors_9x9[ld.x, ld.y].g + hue_orig_colors_9x9[rd.x, rd.y].g) / 4,
                              (hue_orig_colors_9x9[lu.x, lu.y].b + hue_orig_colors_9x9[ru.x, ru.y].b + hue_orig_colors_9x9[ld.x, ld.y].b + hue_orig_colors_9x9[rd.x, rd.y].b) / 4);

        }
        private Hcolor getavecolor_9x9(coordforgrad f, coordforgrad s)
        {
            return new Hcolor((hue_orig_colors_9x9[f.x, f.y].r + hue_orig_colors_9x9[s.x, s.y].r) / 2,
                              (hue_orig_colors_9x9[f.x, f.y].g + hue_orig_colors_9x9[s.x, s.y].g) / 2,
                              (hue_orig_colors_9x9[f.x, f.y].b + hue_orig_colors_9x9[s.x, s.y].b) / 2
                );
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
                if (!((kx == 8) && (ky == 8)) && (!((kx == 0) && (ky == 8))) && (!((kx == 0) && (ky == 0))) && (!((kx == 8) && (ky == 0))) && (!((kx == 4) && (ky == 4))))
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
        private void showgrad_9x9()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //hue_orig_colors_5x5[i, j]= tt;
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).BorderWidth = 0;
                    hue_game_9x9_bottons[i, j].BorderWidth = 0;
                    hue_game_9x9_bottons[i, j].BackgroundColor = Color.FromRgb(hue_game_colors_9x9[i, j].r, hue_game_colors_9x9[i, j].g, hue_game_colors_9x9[i, j].b);
                    //((Button)FindByName("scolor" + i.ToString() + j.ToString())).BackgroundColor = Color.FromRgb(hue_game_colors_5x5[i, j].r, hue_game_colors_5x5[i, j].g, hue_game_colors_5x5[i, j].b);
                }

            }

        }
        private bool is_hue_completed_9x9()
        {
            pair_not_right = 0;
            bool is_hue_completed = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (hue_game_colors_9x9[i, j] != hue_orig_colors_9x9[i, j]) {
                        is_hue_completed = false;

                        pair_not_right++;
                    }
                }

            }
            return is_hue_completed;

        }
        private void game_hue_9x9_field_Click(object sender, EventArgs e)
        {
            ((Button)sender).BorderWidth = 4;
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
                if (is_hue_completed_9x9())

                    arrinf_9x9.Text = " yes ";

                else arrinf_9x9.Text = pair_not_right.ToString();


            }
        }
        private void Button_hue_9x9_gradrand_Clicked(object sender, EventArgs e)
        {
            genrandgrad_9x9();
            is_hue_completed_9x9();
            arrinf_9x9.Text = pair_not_right.ToString();
            showgrad_9x9();
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
                        hue_game_9x9_bottons[i, j].BorderWidth = 6;
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
                        hue_game_9x9_bottons[i, j].BorderWidth = 6;

                        return;

                    }
                }
            }
        }

    }
}