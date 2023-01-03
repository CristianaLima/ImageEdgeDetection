using System.Drawing;

namespace ImageEdgeDetection
{
    //Interface for the Image Filters class
    public interface IImageFilters
    {
        Bitmap BlackWhite(Bitmap Bmp);
        Bitmap MiamiFilter(Bitmap bmp, int alpha, int red, int blue, int green);
        Bitmap RainbowFilter(Bitmap bmp);
    }
}