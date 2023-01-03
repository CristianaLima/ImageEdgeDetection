using System;
using System.Drawing;

namespace ImageEdgeDetection.BLL
{
    //Interface for the AccessData class
    public interface IAccessData
    {
        // Lets the user choose a png/jpg/bmp from his windows file system
        Bitmap LoadImage(String imagePath);

        
        // Lets the user save a png/jpg/bmp on his windows file system
        void SaveImage(Bitmap image, String imagePath);
    }
}
