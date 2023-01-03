using ImageEdgeDetection.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Drawing;
using System.IO;
using UnitTestProject1.Properties;

namespace UnitTestProject1
{

    /// <summary>
    /// FiltersTest unit test class to test the methods of the Filters class
    /// </summary>
    /// 
    [TestClass]
    public class ImageFiltersTest
    {
        // CompareBitmap to compare images
        private CompareBitmap comparatorBitmap = new CompareBitmap();

        // Filters interface that is substituted
        private IImageFilters imageFilter = Substitute.For<IImageFilters>();

        //Filters class
        private ImageFilters imageFilterClass = new ImageFilters();

        //Bitmap source image
        private Bitmap sourceImage = Properties.Resources.barcelona;





        //Test if the miami image filter works
        [TestMethod]
        public void TestFilterMiami()
        {
            Bitmap filteredMiamiImage = Properties.Resources.barcelona;

            imageFilter.MiamiFilter(sourceImage, 1, 1, 10, 1).Returns(filteredMiamiImage);

            Bitmap resultImage = imageFilterClass.MiamiFilter(sourceImage, 1, 1, 10, 1);

            comparatorBitmap.CompareBitmapPixels(imageFilter.MiamiFilter(sourceImage, 1, 1, 10, 1), resultImage);
        }

        //Test if the Miami filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestFilterMiamiNull()
        {
            Bitmap resultImage = imageFilterClass.MiamiFilter(null, 1, 1, 10, 1);
            Assert.IsNull(resultImage);
        }

        //Test if the rainbow image filter works
        [TestMethod]
        public void TestFilterRainbow()
        {
            Bitmap filteredRainbowImage = Properties.Resources.barcelona_rainbow;

            imageFilter.RainbowFilter(sourceImage).Returns(filteredRainbowImage);

            Bitmap resultImage = imageFilterClass.RainbowFilter(sourceImage);

            comparatorBitmap.CompareBitmapPixels(imageFilter.RainbowFilter(sourceImage), resultImage);
        }

        //Test if the Rainbow filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestFilterRainbowNull()
        {
            Bitmap resultImage = imageFilterClass.RainbowFilter(null);
            Assert.IsNull(resultImage);
        }


        //Test if the BlackWhite image filter works
        [TestMethod]
        public void TestFilterBlackWhite()
        {
            Bitmap filteredBlackAndWhiteImage = Properties.Resources.barcelona_blackWhite;

            imageFilter.BlackWhite(sourceImage).Returns(filteredBlackAndWhiteImage);

            Bitmap resultImage = imageFilterClass.BlackWhite(sourceImage);

            comparatorBitmap.CompareBitmapPixels(imageFilter.BlackWhite(sourceImage), resultImage);
        }

        //Test if the BlackWhite filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestFilterBlackWhiteNull()
        {
            Bitmap resultImage = imageFilterClass.BlackWhite(null);
            Assert.IsNull(resultImage);
        }

    }
}