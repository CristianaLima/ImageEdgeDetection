using System;
using System.Drawing;

namespace ImageEdgeDetection.IO

   {
    
    // Interface for the InputOutput class
    public interface IInputOutput
    {
        // Lets the user choose a png/jpg/bmp from his windows file system
        Bitmap LoadImage(String imagePath);

        // Lets the user save a png/jpg/bmp on his windows file system
        void SaveImage(Bitmap image, String imagePath);
    }
}
