using System.Drawing;

namespace ImageEdgeDetection
{
    public interface IFilterXY
    {
        Bitmap filter(int xfilter, int yfilter, Bitmap originalPic);
    }
}