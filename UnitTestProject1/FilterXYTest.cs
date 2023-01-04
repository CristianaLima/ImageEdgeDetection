using ImageEdgeDetection.BLL;
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
        // CompareBitmap to compare images
        private CompareBitmap comparatorBitmap = new CompareBitmap();

        // EdgeDetection interface that is substituted 
        private IFilterXY filterXY = Substitute.For<IFilterXY>();

        
        // EdgeDetection class
        private FilterXY filterXYClass = new FilterXY();

        
        // Bitmap source image
        private Bitmap original = Properties.Resources.ImageOriginal;



        //Test if the x Laplacian5x5 filter and the y Laplacian5x5 filter works
        [TestMethod]
        public void TestFilterLaplacian5x5()
        {

            Bitmap compare = Properties.Resources.Laplacian5x5;

            filterXY.filter(0, 0, original).Returns(compare);

            Bitmap result = filterXY.filter(0, 0, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Prewitt3x3 filter and the y Prewitt3x3 filter works
        [TestMethod]
        public void TestFilterPrewitt3x3()
        {

            Bitmap compare = Properties.Resources.Prewitt3x3;

            filterXY.filter(1, 1, original).Returns(compare);

            Bitmap result = filterXY.filter(1, 1, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Sobel3x3 filter and the y Sobel3x3 filter works
        [TestMethod]
        public void TestFilterSobel3x3()
        {

            Bitmap compare = Properties.Resources.Sobel3x3;

            filterXY.filter(2, 2, original).Returns(compare);

            Bitmap result = filterXYClass.filter(2, 2, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Laplacian5x5 filter and the y Prewitt5x5 filter works
        [TestMethod]
        public void TestFilterLaplacianPrewitt()
        {

            Bitmap compare = Properties.Resources.LaplacianPrewitt;

            filterXY.filter(0, 2, original).Returns(compare);

            Bitmap result = filterXYClass.filter(0, 2, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Laplacian5x5 filter and the y Sobel3x3 filter works
        [TestMethod]
        public void TestFilterLaplacianSobel()
        {

            Bitmap compare = Properties.Resources.LaplacianSobel;

            filterXY.filter(0, 1, original).Returns(compare);

            Bitmap result = filterXYClass.filter(0, 1, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Prewitt3x3 filter and the y Laplacian5x5 filter works
        [TestMethod]
        public void TestFilterPrewittLaplacian()
        {

            Bitmap compare = Properties.Resources.PrewittLaplacian;

            filterXY.filter(2, 0, original).Returns(compare);

            Bitmap result = filterXYClass.filter(2, 0, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Prewitt3x3 filter and the y Sobel3x3 filter works
        [TestMethod]
        public void TestFilterPrewittSobel()
        {

            Bitmap compare = Properties.Resources.PrewittSobel;

            filterXY.filter(2, 1, original).Returns(compare);

            Bitmap result = filterXYClass.filter(2, 1, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Sobel3x3 filter and the y Laplacian5x5 filter works
        [TestMethod]
        public void TestFilterSobelLaplacian()
        {

            Bitmap compare = Properties.Resources.SobelLaplacian;

            filterXY.filter(1, 0, original).Returns(compare);

            Bitmap result = filterXYClass.filter(1, 0, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }

        //Test if the x Sobel3x3 filter and the y Prewitt3x3 filter works
        [TestMethod]
        public void TestFilterSobelPrewitt()
        {

            Bitmap compare = Properties.Resources.SobelPrewitt;

            filterXY.filter(1, 2, original).Returns(compare);

            Bitmap result = filterXYClass.filter(1, 2, original);

            comparatorBitmap.CompareBitmapPixels(compare, result);

        }


        //Test if the filter returns null if it gets Bitmap=null
        [TestMethod]
        public void TestImageNull()
        {
            Bitmap resultImage = filterXYClass.filter(0, 0, null);
            Assert.IsNull(resultImage);
        }

        //Test if the filter uses Laplacian5x5 if it gets X=-1
        [TestMethod]
        public void TestXNull()
        {
            Bitmap compare = Properties.Resources.Laplacian5x5;

            Bitmap result = filterXYClass.filter(-1, 0, original);


            Assert.IsFalse(comparatorBitmap.CompareBitmapPixels(compare, result));
        }

        //Test if the filter uses Laplacian5x5 if it gets Y=-1
        [TestMethod]
        public void TestYNull()
        {
            
            Bitmap compare = Properties.Resources.Laplacian5x5;

            Bitmap result = filterXYClass.filter(0, -1, original);

            Assert.IsFalse(comparatorBitmap.CompareBitmapPixels(compare, result));
        }

    }
}
