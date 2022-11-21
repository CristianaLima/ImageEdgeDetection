using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using UnitTestProject1.Properties;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        FilterXY xYFilterForm = new FilterXY();
        
        [TestMethod]
        public void TestFilterLaplacian3x3()
        {

            Bitmap original = Resources.originalImage;
            Bitmap compare = Resources.Laplacian3x3_Image;

            Bitmap result = xYFilterForm.filter(0, 0, original);

            CompareBitmapPixels(compare, result);

        }

        [TestMethod]
        public void TestFilterSobel3x3VerticalKirsh3x3Horizontal()
        {

            Bitmap original = Resources.originalImage;
            Bitmap compare = Resources.Sobel3x3Vertical_Kirsh3x3Horizontal_Image;

            Bitmap result = xYFilterForm.filter(3, 6, original);
            
            CompareBitmapPixels(compare,result);

        }
        public void CompareBitmapPixels(Bitmap resultImage, Bitmap filteredImage)
        {
            Assert.AreEqual(resultImage.Size, filteredImage.Size);

            for (int y = 0; y < resultImage.Height - 1; y++)
            {
                for (int x = 0; x < resultImage.Width - 1; x++)
                {
                    Assert.AreEqual(resultImage.GetPixel(x, y), filteredImage.GetPixel(x, y));
                }
            }
        }

    }
}
