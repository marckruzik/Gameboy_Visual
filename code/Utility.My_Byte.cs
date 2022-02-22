using System.Collections.Generic;

namespace Utility.My_Byte
{
    public static partial class Utility_Byte
    {

        // Take a part (origin_x, origin_t, width, height) of byte array origin_arr
        // and copy it to (destination_x, destination_y, width, height) of byte array destination_arr
        public static void copy_part (byte[] origin_arr, int origin_arr_width, int origin_arr_height,
            int origin_x, int origin_y,
            int width, int height,
            byte[] destination_arr, int destination_arr_width, int destination_arr_height,
            int destination_x, int destination_y)
        {
            secure_dimension (
                origin_arr_width, origin_arr_height,
                origin_x, origin_y,
                ref width, ref height,
                destination_arr_width, destination_arr_height,
                destination_x, destination_y);

            copy_part_safe (origin_arr, origin_arr_width, origin_arr_height,
                origin_x, origin_y,
                width, height,
                destination_arr, destination_arr_width, destination_arr_height,
                destination_x, destination_y);
        }


        private static void copy_part_safe (byte[] origin_arr, int origin_arr_width, int origin_arr_height,
            int origin_x, int origin_y,
            int width, int height,
            byte[] destination_arr, int destination_arr_width, int destination_arr_height,
            int destination_x, int destination_y)
        {
            for (int y = origin_y; y < origin_y + height; y++)
            {
                int o_index = origin_x * 4 + y * origin_arr_width * 4;
                int d_index = destination_x * 4 + (destination_y - origin_y + y) * destination_arr_width * 4;
                for (int x = origin_x; x < origin_x + width; x++)
                {
                    destination_arr[d_index++] = origin_arr[o_index++];
                    destination_arr[d_index++] = origin_arr[o_index++];
                    destination_arr[d_index++] = origin_arr[o_index++];
                    destination_arr[d_index++] = origin_arr[o_index++];
                }
            }
        }


        public static void secure_dimension (int origin_arr_width, int origin_arr_height,
           int origin_x, int origin_y,
           ref int width, ref int height)
        {
            if (origin_x + width > origin_arr_width)
            {
                width = origin_arr_width - origin_x;
            }
            if (origin_y + height > origin_arr_height)
            {
                height = origin_arr_height - origin_y;
            }
        }


        public static void secure_dimension (int origin_arr_width, int origin_arr_height,
            int origin_x, int origin_y,
            ref int width, ref int height,
            int destination_arr_width, int destination_arr_height,
            int destination_x, int destination_y)
        {
            secure_dimension (
                origin_arr_width, origin_arr_height,
                origin_x, origin_y,
                ref width, ref height);

            if (destination_x + width > destination_arr_width)
            {
                width = destination_arr_width - destination_x;
            }
            if (destination_y + height > destination_arr_height)
            {
                height = destination_arr_height - destination_y;
            }
        }


        public static byte[] from_barr_take_barr (byte[] barr, int barr_width, int barr_height, int x, int y, int width, int height)
        {
            secure_dimension (
                barr_width, barr_height,
                x, y,
                ref width, ref height);

            return from_barr_take_barr_safe (barr, barr_width, barr_height, x, y, width, height);
        }


        private static byte[] from_barr_take_barr_safe (byte[] barr, int barr_width, int barr_height, int x, int y, int width, int height)
        {
            byte[] p_barr = new byte[width * height * 4];

            int destination_cursor = 0;
            for (int cursor_y = y; cursor_y < y + height; cursor_y++)
            {
                int origin_cursor = cursor_y * barr_width * 4 + x * 4;

                for (int cursor_x = x; cursor_x < x + width; cursor_x++)
                {
                    p_barr[destination_cursor++] = barr[origin_cursor++];
                    p_barr[destination_cursor++] = barr[origin_cursor++];
                    p_barr[destination_cursor++] = barr[origin_cursor++];
                    p_barr[destination_cursor++] = barr[origin_cursor++];
                }
            }

            return p_barr;
        }


        public static Dictionary<int, byte[]> get_dico_tile_barr (byte[] barr, int barr_width, int barr_height, int tile_width, int tile_height)
        {
            Dictionary<int, byte[]> dico_tile_barr = new Dictionary<int, byte[]> ();
            int i = 0;
            for (int y = 0; y < barr_height; y += tile_height)
            {
                for (int x = 0; x < barr_width; x += tile_width)
                {
                    byte[] p_barr = from_barr_take_barr (barr, barr_width, barr_height, x, y, tile_width, tile_height);
                    dico_tile_barr[i] = p_barr;
                    i++;
                }
            }
            return dico_tile_barr;
        }


    }
}
