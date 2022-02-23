using System;
using System.Collections.Generic;
using System.Drawing;
using Utility.My_Byte;
using Utility.My_Bitmap;
using nQuant;

namespace NS_Gameboy_Visual
{
    public static class Test
    { 
        public static void test ()
        {
            Bitmap bmp = new Bitmap ("../../../lena256.png");
            byte[] barr = Utility_Bitmap.from_bitmap_get_barr (bmp);

            Utility_Byte.to_black_and_white (barr);

            //byte[] origin_barr = new byte[barr.Length];
            //Array.Copy (barr, origin_barr, barr.Length);

            Random rand = new Random ();

            //Utility_Byte.random_perturbation (barr, rand, 20);

            Utility_Byte.gauss_perturbation (barr, rand, 50);

            List<byte> list_grey = new List<byte> ()
            {
                0, 63, 127, 191, 255
            };

            List<byte> list_threshold = new List<byte> ()
            {
                0, 75, 110, 145, 164, 255
            };
            Utility_Byte.from_bw_to_black_and_white (barr, list_grey, list_threshold);



            /*
            Bitmap h_bmp = new Bitmap (32, 256);
            Graphics h_g = Graphics.FromImage (h_bmp);
            int j = 0;
            foreach (byte grey in list_grey)
            {
                SolidBrush h_brush = new SolidBrush (Color.FromArgb (255, grey, grey, grey));

                h_g.FillRectangle (h_brush, 0.0f, h_bmp.Height - (j + 1) * 51.0f, 32.0f, 51.0f);
                j++;
            }

            byte[] h_barr = Utility_Bitmap.from_bitmap_get_barr (h_bmp);

            byte[] origin_barr = new byte[h_barr.Length];
            Array.Copy (h_barr, origin_barr, h_barr.Length);
            
            swap_gauss (origin_barr, h_barr, list_grey);

            h_bmp = Utility_Bitmap.from_barr_get_bitmap (h_barr, h_bmp.Width, h_bmp.Height);

            h_bmp.Save ("../../../palette-gauss-thresh.png");
            return;
            */
            //byte[] barr2 = nquant_convert (barr, bmp.Width, bmp.Height);
            //Bitmap bmp2 = Utility_Bitmap.from_barr_get_bitmap (barr2, bmp.Width, bmp.Height);


            //barr = swap_gauss (barr, bmp.Width, bmp.Height, list_grey);

            Bitmap bmp2 = Utility_Bitmap.from_barr_get_bitmap (barr, bmp.Width, bmp.Height);

            bmp2.Save ("../../../lena_bw-random.png");
        }



        public static void swap_gauss_origin (byte[] origin_barr, byte[] barr, int barr_width, int barr_height, List<byte> list_grey)
        {
            Random rand = new Random ();


            for (int i = 0; i < barr.Length; i++)
            {

                byte origin_red = origin_barr[i];



            }
        }


        /*
        public static byte[] swap_gauss (byte[] barr, int barr_width, int barr_height, List<byte> list_grey)
        {
            rand = new Random ();

            byte[] destination_barr = new byte[barr.Length];
            for (int i = 0; i < destination_barr.Length; i++)
            {
                destination_barr[i] = 255;
            }


            for (int y = 1; y < barr_height - 1; y++)
            {
                for (int x = 1; x < barr_width - 1; x++)
                {
                    int i = y * barr_width * 4 + x * 4;

                    List<byte> list_neighbour = new List<byte> ();
                    list_neighbour.Add (barr[i - barr_width * 4 - 1 * 4]); // ul
                    list_neighbour.Add (barr[i - barr_width * 4]); // u
                    list_neighbour.Add (barr[i - barr_width * 4 + 1 * 4]); // ur
                    list_neighbour.Add (barr[i - 1 * 4]); // l
                    list_neighbour.Add (barr[i + 1 * 4]); // r
                    list_neighbour.Add (barr[i + barr_width * 4 - 1 * 4]); // dl
                    list_neighbour.Add (barr[i + barr_width * 4]); // d
                    list_neighbour.Add (barr[i + barr_width * 4 + 1 * 4]); // dr
                    list_neighbour.Sort ();
                    byte middle = list_neighbour[4];


                    byte red = barr[i];

                    destination_barr[i] = red;
                    destination_barr[i + 1] = red;
                    destination_barr[i + 2] = red;

                    if (middle == red)
                    {
                        continue;
                    }

                    double a;
                    double b = NextFunctional (0, 2, 100, out a);

                    int gauss = (int) Math.Round (a) - 1;
                    if (red == list_grey[0])
                    {
                        if (gauss == 1)
                        {
                            destination_barr[i] = list_grey[1];
                            destination_barr[i + 1] = list_grey[1];
                            destination_barr[i + 2] = list_grey[1];
                        }
                    }
                    else
                    {
                        int index = list_grey.IndexOf (red);
                        if (gauss == -1)
                        {
                            destination_barr[i] = list_grey[index - 1];
                            destination_barr[i + 1] = list_grey[index - 1];
                            destination_barr[i + 2] = list_grey[index - 1];
                        }
                        else if (gauss == 1 &&
                            index < list_grey.Count - 1)
                        {
                            destination_barr[i] = list_grey[index + 1];
                            destination_barr[i + 1] = list_grey[index + 1];
                            destination_barr[i + 2] = list_grey[index + 1];
                        }
                    }
                }
            }
            return destination_barr;
        }
        */




        private static double Gauss (double x)
        {
            double σ = 1 / Math.Sqrt (2 * Math.PI);
            double variance = Math.Pow (σ, 2);
            double exp = -0.5 * Math.Pow (x, 2) / variance;

            double y = 1 / Math.Sqrt (2 * Math.PI * variance) * Math.Pow (Math.E, exp);

            return y;
        }


        private static double Gauss2 (double x)
        {
            double sig = 1 / Math.Sqrt (2 * Math.PI);

            double exp = -(Math.Pow (x, 2) / (2 * Math.Pow (sig, 2)));
            double y = 1 / (sig * Math.Sqrt (2 * Math.PI)) *
                Math.Pow (Math.E, exp);

            return y;
        }



        /*
        static void curve ()
        {
            Bitmap bmp = new Bitmap (1000, 100);
            Graphics g = Graphics.FromImage (bmp);
            Pen pen = new Pen (Color.Black);

            g.Clear (Color.White);

            List<double> list = new List<double> ();
            rand = new Random ();
            for (int i = 0; i < 1000; i++)
            {
                double x;
                double y = NextFunctional (0, 2, 100, out x);

                list.Add (Math.Round (x) - 1);
                g.DrawRectangle (pen, (float) x, (float) y, 1.0f, 1.0f);
            }

            bmp.Save ("../../../test.png");
        }
        */

    }




}
