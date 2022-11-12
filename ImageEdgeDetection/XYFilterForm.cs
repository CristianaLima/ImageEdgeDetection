using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ImageEdgeDetection
{
    public partial class XYFilterForm : Form
    {

        private Bitmap resultBitmap = null;
        public XYFilterForm()
        {
            InitializeComponent();
            resultBitmap = MainForm.resultBitmap;
            originalPicBox.Image = resultBitmap;
        }

        private void btnSaveNewImage_Click_1(object sender, EventArgs e)
        {
            
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    
                
            }
        }

        private void btnApplyFilters_Click_1(object sender, EventArgs e)
        {
            labelError.Text = " ";
            if (xFilterBox.SelectedIndex != -1 && yFilterBox.SelectedIndex != -1)
            {
                filter(xFilterBox.SelectedIndex, yFilterBox.SelectedIndex);
            }
            else
            {
                labelError.Text = "2 filters must be selected";
            }
        }
        public void filter(int xfilter, int yfilter)
        {
            List<double[,]> allMatrix = Matrix.AllMatrix;
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            xFilterMatrix = allMatrix[xfilter];
            yFilterMatrix = allMatrix[yfilter];

            Bitmap newbitmap = new Bitmap(originalPicBox.Image);
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
                        

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }


                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

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
            resultPicBox.Image = resultbitmap;
            resultBitmap = resultbitmap;
            
        }
    }
}
