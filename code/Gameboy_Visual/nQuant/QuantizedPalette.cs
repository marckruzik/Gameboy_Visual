

using System.Collections.Generic;


namespace nQuant
{
    public class QuantizedPalette
    {
        public QuantizedPalette(int size)
        {
            Colors = new List<Color>();
            PixelIndex = new int[size];
        }
        public IList<Color> Colors { get; private set; }
        public int[] PixelIndex { get; private set; }
    }
}