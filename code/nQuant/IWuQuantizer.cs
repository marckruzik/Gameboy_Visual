

namespace nQuant
{
    public interface IWuQuantizer
    {
        QuantizedPalette QuantizeImage (byte[] arr_color, int bitmapWidth, int bitmapHeight);
    }
}