using ImageEdgeDetection.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEdgeDetection.BLL
{
    public class AccessData : IAccessData
    {
        
        // InputOutput interface
        private IInputOutput inputOutput = new InputOutput();

        
        // Lets the user choose a png/jpg/bmp from his windows file system
        // <returns>A Bitmap selected by the user</returns>
        public Bitmap LoadImage(String imagePath)
        {
            return inputOutput.LoadImage(imagePath);
        }

        
        // Lets the user save a png/jpg/bmp on his windows file system
        // <param name="image">A Bitmap to be saved by the user</param>
        public void SaveImage(Bitmap image, String imagePath)
        {
            inputOutput.SaveImage(image, imagePath);
        }
    }
}