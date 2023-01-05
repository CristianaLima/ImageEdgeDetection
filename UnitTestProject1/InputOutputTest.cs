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
    
    // InputOutputTest unit test class to test the methods of the InputOutput class
    [TestClass]
    public class InputOutputTest
    {
        
        // CompareBitmap to compare images
        private CompareBitmap comparatorBitmap = new CompareBitmap();

       
        // InputOutput interface that is substituted 
        private IAccessData inputOutput = Substitute.For<IAccessData>();

        // InputOutput class
        private AccessData inputOutputClass = new AccessData();

        // Load image test
        [TestMethod]
        public void LoadingImageTest()
        {
            Bitmap loadedImage = Properties.Resources.barcelona;

            String imagePath = @"..\..\Resources\barcelona.bmp";

            inputOutput.LoadImage(imagePath).Returns(loadedImage);

            Bitmap resultImage = inputOutputClass.LoadImage(imagePath);

            comparatorBitmap.CompareBitmapPixels(inputOutput.LoadImage(imagePath), resultImage);
        }

        // Load image test with imagePath = null
        [TestMethod]
        public void LoadingImageNullTest()
        {
            Bitmap loadedImage = null;

            String imagePath = null;

            inputOutput.LoadImage(imagePath).Returns(loadedImage);

            Bitmap resultImage = inputOutputClass.LoadImage(imagePath);

            Assert.AreEqual(inputOutput.LoadImage(imagePath), resultImage);
        }

        // Save image test
        [TestMethod]
        public void SaveImageTest()
        {
            Bitmap saveImage = Properties.Resources.barcelona;

            String imagePathSubstitute = @"..\..\Resources\saveImageTestSubstitute.png";
            String imagePath = @"..\..\Resources\saveImageTest.png";

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

        
        // Save image test with saveImage = null
        [TestMethod]
        public void SaveImageNullTest()
        {
            Bitmap saveImage = null;

            String imagePathSubstitute = @"..\..\Resources\saveImageTestSubstitute.png";
            String imagePath = @"..\..\Resources\saveImageTest.png";

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