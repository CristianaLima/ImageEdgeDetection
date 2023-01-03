using ImageEdgeDetection.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ExtBitmapTest
    {

        //Test the methode CopyToSquareCanvas with a image that is taller than it is wide
        [TestMethod]
        public void TestCopyToSquareCanvasTaller()
        {

            Bitmap original = Properties.Resources.ImageOriginal;
            Bitmap result = original.CopyToSquareCanvas(100);

            Assert.AreEqual(result.Height, 100);

        }

        //Test the methode CopyToSquareCanvas with a image that is wider than it is tall
        [TestMethod]
        public void TestCopyToSquareCanvasWider()
        {

            Bitmap original = Properties.Resources.widtherImage;
            Bitmap result = original.CopyToSquareCanvas(100);

            Assert.AreEqual(result.Width, 100);

        }
    }
}
