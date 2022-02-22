using System.Collections.Generic;
using System;

namespace Utility.My_Byte
{
    public static partial class Utility_Byte
    {

        public static void to_black_and_white (byte[] barr)
        {
            for (int i = 0; i < barr.Length; i+=4)
            {
                byte rgb = (byte)Math.Round (0.299f * barr[i+0] + 0.587f * barr[i+1] + 0.114f * barr[i+2]);
                barr[i] = rgb;
                barr[i+1] = rgb;
                barr[i+2] = rgb;
            }
        }

        public static void from_bw_to_black_and_white (byte[] barr, List<byte> list_grey, List<byte> list_threshold)
        {
            for (int i = 0; i < barr.Length; i += 4)
            {
                byte grey = get_closest (list_grey, list_threshold, barr[i]);
                barr[i] = grey;
                barr[i+1] = grey;
                barr[i+2] = grey;
            }
        }


        public static void random_perturbation (byte[] barr, Random rand, int max_val)
        {
            for (int i = 0; i < barr.Length; i += 4)
            {
                int ran = rand.Next (max_val) - max_val / 2;
                barr[i] = get_byte (barr[i], ran);
                barr[i + 1] = get_byte (barr[i+1], ran);
                barr[i + 2] = get_byte (barr[i+2], ran);
            }
        }


        public static void gauss_perturbation (byte[] barr, Random rand, int max_val)
        {
            for (int i = 0; i < barr.Length; i += 4)
            {
                double a;
                int ran = (int) NextFunctional (rand, 0, max_val, max_val * 0.2f, out a);
                ran -= max_val / 2;
                barr[i] = get_byte (barr[i], ran);
                barr[i + 1] = get_byte (barr[i + 1], ran);
                barr[i + 2] = get_byte (barr[i + 2], ran);
            }
        }

        public static void pow_perturbation (byte[] barr, Random rand, int max_val)
        {
            for (int i = 0; i < barr.Length; i += 4)
            {
                int ran = (int)(Math.Pow (rand.NextDouble (), 0.3f) * max_val);
                ran -= max_val / 2;
                barr[i] = get_byte (barr[i], ran);
                barr[i + 1] = get_byte (barr[i + 1], ran);
                barr[i + 2] = get_byte (barr[i + 2], ran);
            }
        }


        private static double Gauss3 (double x)
        {
            double sig = 0.08;

            double left = 1 / (sig * Math.Sqrt (2 * Math.PI));

            double exp = -(Math.Pow (x, 2) / (2 * Math.Pow (sig, 2)));
            double y = left * Math.Pow (Math.E, exp);

            return y;
        }



        private static double NextFunctional (Random rand, double min, double max, double height, out double x)
        {
            double halfWidth = (max - min) / 2;
            double distance = halfWidth + min;

            x = rand.NextDouble () * 2 - 1;// -1 .. 1

            double y = Gauss3 (x);

            x = halfWidth * x + distance;
            y *= height;

            return y;
        }



        public static byte get_byte (byte bit, int val)
        {
            val += bit;
            val = Math.Min (255, val);
            val = Math.Max (0, val);
            return (byte) val;
        }


        private static byte get_closest (List<byte> list_grey, List<byte> list_threshold, byte color)
        {
            int i = 0;
            for (i = 0; i <= list_grey.Count; i++)
            {
                byte threshold = list_threshold[i];
                if (color <= threshold)
                {
                    if (i == 0)
                    {
                        return list_grey[0];
                    }
                    return list_grey[i-1];
                }
            }
            throw new Exception ("no list grey detected");
        }

    }
}
