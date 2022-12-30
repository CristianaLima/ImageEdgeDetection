using System;
using System.Drawing;

namespace ImageEdgeDetection.IO

   {
    /// <summary>
    /// Interface for the InputOutput class
    /// </summary>
    public interface IInputOutput
    {
        /// <summary>
        /// Lets the user choose a png/jpg/bmp from his windows file system
        /// </summary>
        /// <returns>A Bitmap selected by the user</returns>
        Bitmap LoadImage(String imagePath);

        /// <summary>
        /// Lets the user save a png/jpg/bmp on his windows file system
        /// </summary>
        /// <param name="image">A Bitmap to be saved by the user</param>
        void SaveImage(Bitmap image, String imagePath);
    }
}
