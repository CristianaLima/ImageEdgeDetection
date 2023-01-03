using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageEdgeDetection.BLL
{
    public class FilterXY : IFilterXY
    {
    
        public Bitmap filter(int xfilter, int yfilter, Bitmap originalPic)
        {
            if (xfilter == -1 || yfilter == -1)
                return originalPic;
            if (originalPic == null)
                return null;

            //pick all the matrices from the Matrix class
            List<double[,]> allMatrix = Matrix.AllMatrix;
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            //put the right matrix to the right x and y filter
            xFilterMatrix = allMatrix[xfilter];
            yFilterMatrix = allMatrix[yfilter];

            //applies the filter
            Bitmap newbitmap = new Bitmap(originalPic);
            BitmapData newbitmapData = new BitmapData();
            newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

            byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
            byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

            Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
            newbitmap.UnlockBits(newbitmapData);

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            //does the calculation to put the right color
            for (int offsetY = filterOffset; offsetY <
                newbitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    newbitmap.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;


                    byteOffset = offsetY *
                                    newbitmapData.Stride +
                                    offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                            (filterX * 4) +
                                            (filterY * newbitmapData.Stride);

                            blueX += (double)(pixelbuff[calcOffset]) *
                                        xFilterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];

                            greenX += (double)(pixelbuff[calcOffset + 1]) *
                                        xFilterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];

                            redX += (double)(pixelbuff[calcOffset + 2]) *
                                        xFilterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];

                            blueY += (double)(pixelbuff[calcOffset]) *
                                        yFilterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];

                            greenY += (double)(pixelbuff[calcOffset + 1]) *
                                        yFilterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];

                            redY += (double)(pixelbuff[calcOffset + 2]) *
                                        yFilterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    //adjust the colors to be between 0 and 255
                    if (blueTotal > 255)
                    { blueTotal = 255; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }

                    if (redTotal > 255)
                    { redTotal = 255; }

                    resultbuff[byteOffset] = (byte)(blueTotal);
                    resultbuff[byteOffset + 1] = (byte)(greenTotal);
                    resultbuff[byteOffset + 2] = (byte)(redTotal);
                    resultbuff[byteOffset + 3] = 255;
                }
            }

            Bitmap resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);

            BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                        resultbitmap.Width, resultbitmap.Height),
                                                        ImageLockMode.WriteOnly,
                                                    PixelFormat.Format32bppArgb);

            Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
            resultbitmap.UnlockBits(resultData);
            //return the result
            return resultbitmap;
        }
    }
}
