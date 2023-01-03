using System.Drawing;

namespace ImageEdgeDetection.BLL
{
    //Interface for the FilterXY class
    public interface IFilterXY
    {
        Bitmap filter(int xfilter, int yfilter, Bitmap originalPic);
    }
}