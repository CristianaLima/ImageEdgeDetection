using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ImageEdgeDetection;

namespace TestProject
{
    [TestClass]
    public class TestFilterXY
    {
        FilterXY filter = new FilterXY();

       
        [TestMethod]
        public void TestFilterLaplacian3x3()
        {
           
            StreamReader streamReader = new StreamReader("../../../img/Image_Laplacian3x3_Laplacian3x3.png");
            Bitmap compare = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
            streamReader.Close();

            StreamReader streamReaderOriginal = new StreamReader("../../../img/OriginalImage.png");
            Bitmap original = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
            streamReader.Close();

            Bitmap result =  filter.filter(1, 1, original);

            Assert.AreEqual(result, compare);







        }

       

    }
}
