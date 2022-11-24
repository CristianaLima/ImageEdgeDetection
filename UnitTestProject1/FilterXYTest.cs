using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using UnitTestProject1.Properties;

namespace UnitTestProject1
{
    [TestClass]
    public class FilterXYTest
    {
        FilterXY xYFilterForm = new FilterXY();

        //Method to test if two Bitmaps are identical by each pixel
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

        //Test if the x Laplacian3x3 filter and the y Laplacian3x3 filter works
        [TestMethod]
        public void TestFilterLaplacian3x3()
        {

            Bitmap original = Resources.ImageOriginal;
            Bitmap compare = Resources.Laplacian3x3_Image;

            Bitmap result = xYFilterForm.filter(0, 0, original);

            Assert.IsTrue(CompareBitmapPixels(compare, result));

        }

        //Test if the x Sobel3x3Vertical filter and the y Kirsh3x3Horizonta filter works
        [TestMethod]
        public void TestFilterSobel3x3VerticalKirsh3x3Horizontal()
        {

            Bitmap original = Resources.ImageOriginal;
            Bitmap compare = Resources.Sobel3x3Vertical_Kirsh3x3Horizontal_Image;

            Bitmap result = xYFilterForm.filter(3, 6, original);

            Assert.IsTrue(CompareBitmapPixels(compare, result));

        }
        

    }
}
