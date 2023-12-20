using System;
using System.Reflection;
using Xamarin.Forms;
using System.IO;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Tokki
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

    public class cord_grass
    {
        public float x1;
        public float y1;
        public float x2;
        public float y2;
        public int crtm;
        public cord_grass(float x1, float y1, float x2, float y2, int crtm)
        {
            this.y1 = y1;
            this.x1 = x1;
            this.x2 = x2;
            this.y2 = y2;
            this.crtm = crtm;
        }
    }

    static class BitmapExtensions
    {
        public static SKBitmap LoadBitmapResource(Type type, string resourceID)
        {
            Assembly assembly = type.GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                return SKBitmap.Decode(stream);
            }
        }

        public static uint RgbaMakePixel(byte red, byte green, byte blue, byte alpha = 255)
        {
            return (uint)((alpha << 24) | (blue << 16) | (green << 8) | red);
        }

        public static void RgbaGetBytes(this uint pixel, out byte red, out byte green, out byte blue, out byte alpha)
        {
            red = (byte)pixel;
            green = (byte)(pixel >> 8);
            blue = (byte)(pixel >> 16);
            alpha = (byte)(pixel >> 24);
        }

        public static uint BgraMakePixel(byte blue, byte green, byte red, byte alpha = 255)
        {
            return (uint)((alpha << 24) | (red << 16) | (green << 8) | blue);
        }

        public static void BgraGetBytes(this uint pixel, out byte blue, out byte green, out byte red, out byte alpha)
        {
            blue = (byte)pixel;
            green = (byte)(pixel >> 8);
            red = (byte)(pixel >> 16);
            alpha = (byte)(pixel >> 24);
        }

        public static void DrawBitmap(this SKCanvas canvas, SKBitmap bitmap, SKRect dest,
                                      BitmapStretch stretch,
                                      BitmapAlignment horizontal = BitmapAlignment.Center,
                                      BitmapAlignment vertical = BitmapAlignment.Center,
                                      SKPaint paint = null)
        {
            if (stretch == BitmapStretch.Fill)
            {
                canvas.DrawBitmap(bitmap, dest, paint);
            }
            else
            {
                float scale = 1;

                switch (stretch)
                {
                    case BitmapStretch.None:
                        break;

                    case BitmapStretch.Uniform:
                        scale = Math.Min(dest.Width / bitmap.Width, dest.Height / bitmap.Height);
                        break;

                    case BitmapStretch.UniformToFill:
                        scale = Math.Max(dest.Width / bitmap.Width, dest.Height / bitmap.Height);
                        break;
                }

                SKRect display = CalculateDisplayRect(dest, scale * bitmap.Width, scale * bitmap.Height,
                                                      horizontal, vertical);

                canvas.DrawBitmap(bitmap, display, paint);
            }
        }

        public static void DrawBitmap(this SKCanvas canvas, SKBitmap bitmap, SKRect source, SKRect dest,
                                      BitmapStretch stretch,
                                      BitmapAlignment horizontal = BitmapAlignment.Center,
                                      BitmapAlignment vertical = BitmapAlignment.Center,
                                      SKPaint paint = null)
        {
            if (stretch == BitmapStretch.Fill)
            {
                canvas.DrawBitmap(bitmap, source, dest, paint);
            }
            else
            {
                float scale = 1;

                switch (stretch)
                {
                    case BitmapStretch.None:
                        break;

                    case BitmapStretch.Uniform:
                        scale = Math.Min(dest.Width / source.Width, dest.Height / source.Height);
                        break;

                    case BitmapStretch.UniformToFill:
                        scale = Math.Max(dest.Width / source.Width, dest.Height / source.Height);
                        break;
                }

                SKRect display = CalculateDisplayRect(dest, scale * source.Width, scale * source.Height,
                                                      horizontal, vertical);

                canvas.DrawBitmap(bitmap, source, display, paint);
            }
        }

        static SKRect CalculateDisplayRect(SKRect dest, float bmpWidth, float bmpHeight,
                                           BitmapAlignment horizontal, BitmapAlignment vertical)
        {
            float x = 0;
            float y = 0;

            switch (horizontal)
            {
                case BitmapAlignment.Center:
                    x = (dest.Width - bmpWidth) / 2;
                    break;

                case BitmapAlignment.Start:
                    break;

                case BitmapAlignment.End:
                    x = dest.Width - bmpWidth;
                    break;
            }

            switch (vertical)
            {
                case BitmapAlignment.Center:
                    y = (dest.Height - bmpHeight) / 2;
                    break;

                case BitmapAlignment.Start:
                    break;

                case BitmapAlignment.End:
                    y = dest.Height - bmpHeight;
                    break;
            }

            x += dest.Left;
            y += dest.Top;

            return new SKRect(x, y, x + bmpWidth, y + bmpHeight);
        }
    }

    public enum BitmapStretch
    {
        None,
        Fill,
        Uniform,
        UniformToFill,
        AspectFit = Uniform,
        AspectFill = UniformToFill
    }

    public enum BitmapAlignment
    {
        Start,
        Center,
        End
    }
    public partial class lawn : ContentPage
	{
        int counter = 0;
        int mincnt = 0;
        int graw_speed = 999;
        public List<cord_grass> crd = new List<cord_grass>();
        double x, y;
        float xan, yan;

        SKBitmap bitmap2 = BitmapExtensions.LoadBitmapResource(
            typeof(MainPage),
            "Tokki.pictures.lawn.foreground_lawn.png");
        SKBitmap bitcutter = BitmapExtensions.LoadBitmapResource(
            typeof(MainPage), "Tokki.pictures.lawn.kosilka.png");

        float Dwidth = (float)DeviceDisplay.MainDisplayInfo.Width;
        float Dheight = (float)DeviceDisplay.MainDisplayInfo.Height;
        float Iwidth;
        float Iheight;
        float x1;
        float y1;
        public lawn ()
		{
			InitializeComponent ();
            
            var panGestureRecognizer = new PanGestureRecognizer();
            panGestureRecognizer.PanUpdated += OnPanUpdated;
            canvas.GestureRecognizers.Add(panGestureRecognizer);
            
            xan = 200;
            yan = 200;

            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    mincnt = counter / graw_speed;
                   
                    canvas.InvalidateSurface();
                });
                return counter++ > -1;

            });
        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            Iwidth = info.Width;
            Iheight = info.Height;
            // Рисуем основное изображение
            canvas.DrawBitmap(bitmap2, new SKRect(0, 0, bitmap2.Width, bitmap2.Height));

            // Создание маски

            using (SKPaint maskPaint = new SKPaint())
            {
                int k = crd.Count-1;
                maskPaint.BlendMode = SKBlendMode.DstOut;
                maskPaint.StrokeWidth = 200;
                maskPaint.StrokeCap = SKStrokeCap.Round;
                if (k > 0)
                    while ((k > 0) && (crd[k].crtm >= mincnt))
                    {

                        canvas.DrawLine((crd[k].x1 / 1080 * info.Width), (crd[k].y1 / 2560) * info.Height, (crd[k].x2 / 1080 * info.Width), (crd[k].y2 / 2560) * info.Height, maskPaint);
                        k--;
                    }
                if (mincnt > 2 && k>=0)
                    crd.RemoveRange(0, k);
               
            //tst.Text =k.ToString()+" "+mincnt.ToString()+" "+crd.Count+" "+counter/33;
            }
            //рисуется косилка
            using (SKPaint cut = new SKPaint()) {
                canvas.RotateDegrees(-counter*10, (xan / 1080) * info.Width, (yan / 2560) * info.Height);
                
                

                canvas.DrawBitmap(bitcutter, new SKRect((xan / 1080) * info.Width - 100, (yan / 2560) * info.Height - 100, (xan / 1080) * info.Width + 100, (yan / 2560) * info.Height + 100));
            }


        }


        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Started)
            {

                x = xan;
                y = yan;

                x1 = xan;
                y1 = yan;


            }
            if (e.StatusType == GestureStatus.Running)
            {



                if ((((float)(x + e.TotalX) / 1080) * Iwidth) > Dwidth)
                {
                    xan = ((Dwidth) * 1080 / Iwidth);
                }
                else if ((float)(x + e.TotalX) < 0)
                {
                    xan = 0;
                }
                else xan = (float)(x + e.TotalX);




                if (((float)(y + e.TotalY) / 2560 * Iheight) > Dheight - 120)
                {
                    yan = ((Dheight - 120) * 2560 / Iheight);
                }
                else if ((float)(y + e.TotalY) < 0)
                {
                    yan = 0;
                }
                else yan = (float)(y + e.TotalY);

                crd.Add(new cord_grass(x1, y1, xan, yan, mincnt + 1));
                x1 = xan;
                y1 = yan;


            }

        }
        private async void game_lawn_exit_Click(object sender, EventArgs e)
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