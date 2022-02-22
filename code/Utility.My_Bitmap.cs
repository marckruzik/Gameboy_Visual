using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Utility.My_Byte;

namespace Utility.My_Bitmap
{
    public static partial class Utility_Bitmap
    {

        // by Florian Block
        // http://florianblock.blogspot.com/2008/06/copying-dynamically-created-bitmap-to.html
        public static byte[] from_bitmap_get_barr (Bitmap bitmap)
        {
            // Lock the bitmap data
            BitmapData data = bitmap.LockBits (
                new Rectangle (0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // calculate the byte size: for PixelFormat.Format32bppArgb (standard for GDI bitmaps) it's the hight * stride
            int bufferSize = data.Height * data.Stride; // stride already incorporates 4 bytes per pixel

            // create buffer
            byte[] barr = new byte[bufferSize];

            // copy bitmap data into buffer
            Marshal.Copy (data.Scan0, barr, 0, barr.Length);

            // unlock the bitmap data
            bitmap.UnlockBits (data);

            switch_rb (barr);

            return barr;
        }


        public static void switch_rb (byte[] barr)
        {
            for (int i = 0; i < barr.Length; i += 4)
            {
                byte t = barr[i];
                barr[i] = barr[i + 2];
                barr[i + 2] = t;
            }
        }

        public static Bitmap from_barr_get_bitmap (byte[] barr, int width, int height)
        {
            switch_rb (barr);

            Bitmap bitmap = new Bitmap (width, height, PixelFormat.Format32bppArgb);
            
            //Create a BitmapData and Lock all pixels to be written 
            BitmapData bmpData = bitmap.LockBits (
                                 new Rectangle (0, 0, bitmap.Width, bitmap.Height),
                                 ImageLockMode.WriteOnly, bitmap.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy (barr, 0, bmpData.Scan0, barr.Length);

            //Unlock the pixels
            bitmap.UnlockBits (bmpData);

            //Return the bitmap 
            return bitmap;
        }

        public static Bitmap get_part (Bitmap bitmap, int x, int y, int width, int height)
        {
            byte[] barr = from_bitmap_get_barr (bitmap);
            byte[] barr_part = Utility_Byte.from_barr_take_barr (barr, bitmap.Width, bitmap.Height, x, y, width, height);
            return from_barr_get_bitmap (barr_part, width, height);
        }


        public static Bitmap get_tile (Bitmap bitmap, int tile_width, int tile_height, int tile)
        {
            int nb_w = bitmap.Width / tile_width;
            int x = (tile % nb_w) * tile_width;
            int y = (tile / nb_w) * tile_height;
            return get_part (bitmap, x, y, tile_width, tile_height);
        }


        public static Dictionary<int, Bitmap> get_dico_tile_bitmap (Bitmap bitmap, int tile_width, int tile_height)
        {
            byte[] barr = from_bitmap_get_barr (bitmap);
            Dictionary<int, byte[]> dico_tile_barr = Utility_Byte.get_dico_tile_barr (barr, bitmap.Width, bitmap.Height, tile_width, tile_height);
            Dictionary<int, Bitmap> dico_tile_bitmap = new Dictionary<int,Bitmap> ();
            foreach (KeyValuePair<int, byte[]> tile_barr in dico_tile_barr)
            {
                dico_tile_bitmap[tile_barr.Key] = from_barr_get_bitmap (tile_barr.Value, tile_width, tile_height);
            }
            return dico_tile_bitmap;
        }

        public static Dictionary<int, Bitmap> get_dico_tile_bitmap (string file_path, int tile_width, int tile_height)
        {
            Bitmap bitmap = new Bitmap (file_path);
            return get_dico_tile_bitmap (bitmap, tile_width, tile_height);
        }

    }
}