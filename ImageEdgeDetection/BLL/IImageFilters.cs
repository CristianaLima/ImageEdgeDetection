using System.Drawing;

namespace ImageEdgeDetection
{
    public interface IImageFilters
    {
        Bitmap BlackWhite(Bitmap Bmp);
        Bitmap MiamiFilter(Bitmap bmp, int alpha, int red, int blue, int green);
        Bitmap RainbowFilter(Bitmap bmp);
    }
}