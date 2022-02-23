using System;
using System.Collections.Generic;
using System.Drawing;
using Utility.My_Byte;
using Utility.My_Bitmap;
using System.Text.RegularExpressions;
using nQuant;

using Color = System.Drawing.Color;

namespace NS_Gameboy_Visual
{
    public static class Gameboy_Visual
    {
        public static Bitmap from_path_get_gbbmp (string path, bool noise)
        {
            List<Color> list_color = new List<Color>
            {
                Color.FromArgb(255,8,24,32),
                Color.FromArgb(255,52,104,86),
                Color.FromArgb(255,136,192,112),
                Color.FromArgb(255,224,248,208)
            };
            return from_path_and_list_color_get_gbbmp (path, noise, list_color);
        }


        public static Bitmap from_path_and_list_color_get_gbbmp (string path, bool noise, List<Color> list_color)
        {
            int max_color = list_color.Count;

            Bitmap bmp = new Bitmap (path);
            int width = bmp.Width;
            int height = bmp.Height;
            byte[] barr = Utility_Bitmap.from_bitmap_get_barr (bmp);
            bmp.Dispose ();


            Utility_Byte.to_black_and_white (barr);

            if (noise == true)
            {
                Random rand = new Random (1234);
                Utility_Byte.random_perturbation (barr, rand, 50);
                //Utility_Byte.gauss_perturbation (barr, rand, 50);
                //Utility_Byte.pow_perturbation (barr, rand, 100);
            }

            byte[] barr2 = nquant_convert (barr, width, height, max_color);


            List<byte> list_grey = new List<byte> ();
            for (int i = 0; i < barr2.Length; i += 4)
            {
                byte red = barr2[i];
                if (list_grey.Contains (red) == false)
                {
                    list_grey.Add (red);
                }
            }
            list_grey.Sort ();
            for (int i = 0; i < barr2.Length; i += 4)
            {
                byte red = barr2[i];
                int index = list_grey.IndexOf (red);
                Color color = list_color[index];
                barr2[i] = color.R;
                barr2[i + 1] = color.G;
                barr2[i + 2] = color.B;
            }

            Bitmap gbbmp = Utility_Bitmap.from_barr_get_bitmap (barr2, width, height);

            return gbbmp;
        }

        public static List<Color> from_colors_get_list_color (string[] colors)
        {
            List<Color> list_color = new List<Color> ();

            Regex reg = new Regex (@"\( *(\d+), *(\d+), *(\d+) *\)");
            for (int i = 1; i < colors.Length; i++)
            {
                string arg = colors[i];
                Match m = reg.Match (arg);
                if (m.Success == false)
                {
                    continue;
                }
                byte r = byte.Parse (m.Groups[1].ToString ());
                byte g = byte.Parse (m.Groups[2].ToString ());
                byte b = byte.Parse (m.Groups[3].ToString ());
                Color color = Color.FromArgb (255, r, g, b);
                list_color.Add (color);
            }

            return list_color;
        }


        public static byte[] nquant_convert (byte[] arr_color, int bitmapWidth, int bitmapHeight, int max_color)
        {

            const int alphaThreshold = 10;
            const int alphaFader = 70;
            var quantizer = new WuQuantizer ();
            quantizer.set_max_color (max_color);

            QuantizedPalette quantized_palette = quantizer.QuantizeImage (arr_color, bitmapWidth, bitmapHeight, alphaThreshold, alphaFader);

            byte[] arr_color2 = new byte[arr_color.Length];
            for (int i = 0; i < quantized_palette.PixelIndex.Length; i++)
            {
                int index = quantized_palette.PixelIndex[i];
                if (index == -1)
                {
                    // Transparent pixel
                    continue;
                }
                nQuant.Color color = quantized_palette.Colors[index];
                // nQuant is using another order for its values (see Pixel)
                // so we change them
                arr_color2[i * 4] = color.b;
                arr_color2[i * 4 + 1] = color.g;
                arr_color2[i * 4 + 2] = color.r;
                arr_color2[i * 4 + 3] = color.a;
            }

            return arr_color2;
        }

    }
}
