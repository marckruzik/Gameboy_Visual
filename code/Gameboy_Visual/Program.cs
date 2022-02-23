using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.IO;

using Color = System.Drawing.Color;

namespace NS_Gameboy_Visual
{
    class Program
    {
        static void Main (string[] args)
        {
            work (args);

        }


        public static void work (string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine ("please specify a path : \n" + "exe path [number of colors] [(R,G,B) (R,G,B)...]");
                Console.ReadKey ();
                return;
            }

            string path = args[0];
            if (File.Exists (path) == false)
            {
                Console.WriteLine ("the following file doesn't exist : \n" + path);
                return;
            }

            Bitmap bmp2;
            if (args.Length == 1)
            {
                bmp2 = Gameboy_Visual.from_path_get_gbbmp (path, true);
            }
            else
            {
                string[] colors = args.ToList ().GetRange (1, args.Length - 1).ToArray ();
                List<Color> list_color = Gameboy_Visual.from_colors_get_list_color (colors);
                bmp2 = Gameboy_Visual.from_path_and_list_color_get_gbbmp (path, true, list_color);
            }

            string path2 = Path.Combine (Path.GetDirectoryName (path), Path.GetFileNameWithoutExtension (path)) + "-mod" + ".png";

            bmp2.Save (path2);
        }

    }
}
