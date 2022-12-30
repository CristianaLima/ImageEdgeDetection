using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEdgeDetection.IO
{
    /// <summary>
    /// InputOuput class that provides methods to load and save images
    /// </summary>
    public class InputOutput : IInputOutput
    {
        /// <summary>
        /// Lets the user choose a png/jpg/bmp from his windows file system
        /// </summary>
        /// <returns>A Bitmap selected by the user</returns>
        public Bitmap LoadImage(String imagePath)
        {
            Bitmap image = null;
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(imagePath);
                image = new Bitmap(streamReader.BaseStream);
                streamReader.Close();
            }
            catch
            {
                image = null;
            }

            return image;
        }

        /// <summary>
        /// Lets the user save a png/jpg/bmp on his windows file system
        /// </summary>
        /// <param name="image">A Bitmap to be saved by the user</param>
        public void SaveImage(Bitmap image, String imagePath)
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
