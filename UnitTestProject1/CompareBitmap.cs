using System;
using System.Drawing;

namespace UnitTestProject1
{
    public class CompareBitmap
    {
        public Boolean CompareBitmapPixels(Bitmap resultImage, Bitmap filteredImage)
        {
            if (resultImage.Size != filteredImage.Size)
                return false;

            for (int y = 0; y < resultImage.Height - 1; y++)
            {
                for (int x = 0; x < resultImage.Width - 1; x++)
                {
                    if (resultImage.GetPixel(x, y) != filteredImage.GetPixel(x, y))
                        return false;
                }
            }
            return true;
        }
    }
}
