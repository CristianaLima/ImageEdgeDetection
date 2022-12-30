using ImageEdgeDetection;
using ImageEdgeDetection.BLL;
using ImageEdgeDetection.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace UnitTestProject1
{
    /// <summary>
    /// InputOutputTest unit test class to test the methods of the InputOutput class
    /// </summary>
    [TestClass]
    public class InputOutputTest
    {
        /// <summary>
        /// CompareBitmap to compare images
        /// </summary>
        private CompareBitmap comparatorBitmap = new CompareBitmap();

        /// <summary>
        /// InputOutput interface that is substituted 
        /// </summary>
        private IAccessData inputOutput = Substitute.For<IAccessData>();

        /// <summary>
        /// InputOutput class
        /// </summary>
        private AccessData inputOutputClass = new AccessData();

        /// <summary>
        /// Load image test
        /// </summary>
        [TestMethod]
        public void LoadImageTest()
        {
            Bitmap loadedImage = Properties.Resources.barcelona;

            String imagePath = @"..\..\Resources\barcelona.bmp";

            inputOutput.LoadImage(imagePath).Returns(loadedImage);

            Bitmap resultImage = inputOutputClass.LoadImage(imagePath);

            comparatorBitmap.CompareBitmapPixels(inputOutput.LoadImage(imagePath), resultImage);
        }

        /// <summary>
        /// Load image test with imagePath = null
        /// </summary>
        [TestMethod]
        public void LoadImageNullTest()
        {
            Bitmap loadedImage = null;

            String imagePath = null;

            inputOutput.LoadImage(imagePath).Returns(loadedImage);

            Bitmap resultImage = inputOutputClass.LoadImage(imagePath);

            Assert.AreEqual(inputOutput.LoadImage(imagePath), resultImage);
        }

        /// <summary>
        /// Save image test
        /// </summary>
        [TestMethod]
        public void SaveImage()
        {
            Bitmap saveImage = Properties.Resources.barcelona;

            String imagePathSubstitute = @"..\..\Resources\saveImageTestSubstitute.png";
            String imagePath = @"..\..\Resources\saveImageTest.png";

            // https://nsubstitute.github.io/help/callbacks/
            // https://nsubstitute.github.io/help/return-from-function/
            inputOutput.When(
                call => call.SaveImage(saveImage, imagePathSubstitute)
            ).Do(
                x =>
                {
                    StreamWriter streamWriter = new StreamWriter(x.Arg<String>(), false);
                    x.Arg<Bitmap>().Save(streamWriter.BaseStream, ImageFormat.Png);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            );

            inputOutput.SaveImage(saveImage, imagePathSubstitute);
            inputOutputClass.SaveImage(saveImage, imagePath);

            Bitmap substituteImage = new Bitmap(imagePathSubstitute);
            Bitmap resultImage = new Bitmap(imagePath);

            comparatorBitmap.CompareBitmapPixels(substituteImage, resultImage);
        }

        /// <summary>
        /// Save image test with saveImage = null
        /// </summary>
        [TestMethod]
        public void SaveImageNullTest()
        {
            Bitmap saveImage = null;

            String imagePathSubstitute = @"..\..\Resources\saveImageTestSubstitute.png";
            String imagePath = @"..\..\Resources\saveImageTest.png";

            // https://nsubstitute.github.io/help/throwing-exceptions/
            inputOutput.When(
                call => call.SaveImage(saveImage, imagePathSubstitute)
            ).Do(
                x => { throw new InputOutputException(); }
            );

            Assert.ThrowsException<InputOutputException>(() => inputOutput.SaveImage(null, imagePathSubstitute));
            Assert.ThrowsException<InputOutputException>(() => inputOutputClass.SaveImage(null, imagePath));
        }
    }
}