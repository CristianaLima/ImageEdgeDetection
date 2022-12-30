using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Drawing;
using System.IO;
using UnitTestProject1.Properties;

namespace UnitTestProject1
{
    [TestClass]
    public class FilterXYTest
    {
        /// <summary>
        /// CompareBitmap to compare images
        /// </summary>
        private CompareBitmap comparatorBitmap = new CompareBitmap();

        /// <summary>
        /// EdgeDetection interface that is substituted 
        /// </summary>
        private IFilterXY filterXY = Substitute.For<IFilterXY>();

        /// <summary>
        /// EdgeDetection class
        /// </summary>
        private FilterXY filterXYClass = new FilterXY();

        /// <summary>
        /// Bitmap source image
        /// </summary>
        private Bitmap original = Properties.Resources.ImageOriginal;

     //   FilterXY xYFilterForm = new FilterXY();

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
        public void TestFilterLaplacian5x5()
        {

            Bitmap compare = Properties.Resources.Laplacian5x5;

            filterXY.filter(1, 1, original).Returns(compare);

            Bitmap result = filterXY.filter(1, 1, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Prewitt3x3 filter and the y Prewitt3x3 filter works
        [TestMethod]
        public void TestFilterPrewitt3x3()
        {

            Bitmap compare = Properties.Resources.Prewitt3x3;

            filterXY.filter(2, 2, original).Returns(compare);

            Bitmap result = filterXY.filter(2, 2, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Sobel3x3 filter and the y Sobel*x3 filter works
        [TestMethod]
        public void TestFilterSobel3x3()
        {

            Bitmap compare = Properties.Resources.Sobel3x3;

            filterXY.filter(3, 3, original).Returns(compare);

            Bitmap result = filterXY.filter(3, 3, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

       
        //Test if the filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestImageNull()
        {
            Bitmap resultImage = filterXY.filter(0, 0, null);
            Assert.IsNull(resultImage);
        }

        //Test if the filter uses Laplacian5x5 if it gets X=-1
        [TestMethod]
        public void TestXNull()
        {
            Bitmap compare = Properties.Resources.Laplacian5x5;

            Bitmap result = filterXY.filter(-1, 0, original);

            Assert.IsFalse(CompareBitmapPixels(compare, result));
        }

        //Test if the filter uses Laplacian5x5 if it gets Y=-1
        [TestMethod]
        public void TestYNull()
        {
            
            Bitmap compare = Properties.Resources.Laplacian5x5;

            Bitmap result = filterXY.filter(0, -1, original);

            Assert.IsFalse(CompareBitmapPixels(compare, result));
        }

    }
}
