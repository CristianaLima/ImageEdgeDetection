using System.Drawing;

namespace ImageEdgeDetection
{
    //Interface for the FilterXY class
    public interface IFilterXY
    {
        Bitmap filter(int xfilter, int yfilter, Bitmap originalPic);
    }
}