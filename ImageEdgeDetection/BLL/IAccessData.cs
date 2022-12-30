using System;
using System.Drawing;

namespace ImageEdgeDetection
{
    public interface IAccessData
    {
        // Lets the user choose a png/jpg/bmp from his windows file system
        // <returns>A Bitmap selected by the user</returns>
        Bitmap LoadImage(String imagePath);

        
        // Lets the user save a png/jpg/bmp on his windows file system
        // <param name="image">A Bitmap to be saved by the user</param>
        void SaveImage(Bitmap image, String imagePath);
    }
}
