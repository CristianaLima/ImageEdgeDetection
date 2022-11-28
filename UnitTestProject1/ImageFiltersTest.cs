using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using UnitTestProject1.Properties;

namespace UnitTestProject1
{
    [TestClass]
    public class ImageFiltersTest
    {
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

        //Test if the rainbow image filter works
        [TestMethod]
        public void TestFilterRainbow()
        {
            Bitmap filteredRainbowImage = new Bitmap(Properties.Resources.barcelona_rainbow);

            Bitmap sourceImage = new Bitmap(Properties.Resources.barcelona);
            Bitmap resultImage = ImageFilters.RainbowFilter(sourceImage);

            Assert.IsTrue( CompareBitmapPixels(resultImage, filteredRainbowImage));
        }

        //Test if the Rainbow filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestFilterRainbowNull()
        {
            Bitmap resultImage = ImageFilters.RainbowFilter(null);
            Assert.IsNull(resultImage);
        }


        //Test if the BlackWhite image filter works
        [TestMethod]
        public void TestFilterBlackWhite()
        {
            Bitmap filteredBlackWhiteImage = new Bitmap(Properties.Resources.barcelona_blackWhite);

            Bitmap sourceImage = new Bitmap(Properties.Resources.barcelona);
            Bitmap resultImage = ImageFilters.BlackWhite(sourceImage);

            Assert.IsTrue(CompareBitmapPixels(resultImage, filteredBlackWhiteImage));
        }

        //Test if the BlackWhite filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestFilterBlackWhiteNull()
        {
            Bitmap resultImage = ImageFilters.BlackWhite(null);
            Assert.IsNull(resultImage);
        }

    }
}