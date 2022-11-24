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

        //Test if the x Sobel3x3Vertical filter and the y Kirsh3x3Horizontal filter works
        [TestMethod]
        public void TestFilterSobel3x3VerticalKirsh3x3Horizontal()
        {

            Bitmap original = Resources.ImageOriginal;
            Bitmap compare = Resources.Sobel3x3Vertical_Kirsh3x3Horizontal_Image;

            Bitmap result = xYFilterForm.filter(3, 6, original);

            Assert.IsTrue(CompareBitmapPixels(compare, result));

        }

        //Test if the x Laplacian5x5 filter and the y Prewitt3x3Horizontal filter works
        [TestMethod]
        public void TestFilterLaplacian5x5Prewitt3x3Horizontal()
        {

            Bitmap original = Resources.ImageOriginal;
            Bitmap compare = Resources.Laplacian5x5_Prewitt3x3Horizontal_Image;

            Bitmap result = xYFilterForm.filter(1, 4, original);

            Assert.IsTrue(CompareBitmapPixels(compare, result));

        }

        //Test if the filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestImageNull()
        {
            Bitmap resultImage = xYFilterForm.filter(0, 0, null);
            Assert.IsNull(resultImage);
        }

        //Test if the filter uses Laplacian3x3 if it gets X=-1
        [TestMethod]
        public void TestXNull()
        {
            Bitmap original = Resources.ImageOriginal;
            Bitmap compare = Resources.Laplacian3x3_Image;

            Bitmap result = xYFilterForm.filter(-1, 0, original);

            Assert.IsFalse(CompareBitmapPixels(compare, result));
        }

        //Test if the filter uses Laplacian3x3 if it gets Y=-1
        [TestMethod]
        public void TestYNull()
        {
            Bitmap original = Resources.ImageOriginal;
            Bitmap compare = Resources.Laplacian3x3_Image;

            Bitmap result = xYFilterForm.filter(0, -1, original);

            Assert.IsFalse(CompareBitmapPixels(compare, result));
        }


    }
}
