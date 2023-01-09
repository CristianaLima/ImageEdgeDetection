using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEdgeDetection.IO
{
    
    // InputOuput class that provides methods to load and save images
    public class InputOutput : IInputOutput
    {
        
        // Lets the user choose a png/jpg/bmp from his windows file system
        public Bitmap LoadImage(string imagePath)
        {
            Bitmap image = null;
            

            try
            {
                StreamReader streamReader = new StreamReader(imagePath);

                image = new Bitmap(streamReader.BaseStream);
                streamReader.Close();
            }
            catch
            {
                image = null;
            }

            return image;
        }

        // Lets the user save a png/jpg/bmp on his windows file system
        public void SaveImage(Bitmap image, string imagePath)
        {
            if (image == null)
            {
                throw new InputOutputException();
            }

            if (imagePath != null)
            {
                string fileExtension = Path.GetExtension(imagePath).ToUpper();
                ImageFormat imgFormat = ImageFormat.Png;

                StreamWriter streamWriter = new StreamWriter(imagePath, false);

                image.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
