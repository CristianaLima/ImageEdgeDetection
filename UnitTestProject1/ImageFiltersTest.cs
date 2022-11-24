﻿using ImageEdgeDetection;
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

        //Test if the rainbow image filter works
        [TestMethod]
        public void TestFilterRainbow()
        {
            Bitmap filteredRainbowImage = new Bitmap(Properties.Resources.barcelona_rainbow);

            Bitmap sourceImage = new Bitmap(Properties.Resources.barcelona);
            Bitmap resultImage = ImageFilters.RainbowFilter(sourceImage);

            CompareBitmapPixels(resultImage, filteredRainbowImage);
        }

        
        //Test if the BlackWhite image filter works
        [TestMethod]
        public void TestFilterBlackWhite()
        {
            Bitmap filteredBlackWhiteImage = new Bitmap(Properties.Resources.barcelona_blackWhite);

            Bitmap sourceImage = new Bitmap(Properties.Resources.barcelona);
            Bitmap resultImage = ImageFilters.BlackWhite(sourceImage);

            CompareBitmapPixels(resultImage, filteredBlackWhiteImage);
        }

    }
}