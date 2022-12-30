/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ImageEdgeDetection.BLL;

namespace ImageEdgeDetection
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ImageFilter interface
        /// </summary>
        private IImageFilters imageFilter = new ImageFilters();

        /// <summary>
        /// EdgeDetection interface
        /// </summary>
        private IFilterXY filterXY = new FilterXY();

        /// <summary>
        /// DataAccess interface from BLL
        /// </summary>
        private IAccessData dataAccess = new AccessData();

        /// <summary>
        /// Image in the picture box without any filter applied
        /// </summary>
        private Image origin;

        //result that XYFilterForm will pick
        public static Bitmap resultBitmap = null;

        public MainForm()
        {
            InitializeComponent();
        }

        //when you click in the load image button
        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            //it will hide the labelError 
            labelError.Text = " ";
            //open your files to go pick an image
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                Bitmap originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                //show the image
                resultBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                origin = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = resultBitmap;
                              
            }
        }

        //when you click to the next page button
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //see if you load an image or not
            if (resultBitmap != null)
            {
                //hide this window
                this.Hide();
                //create and open the XYFilterForm
                XYFilterForm xYFilterForm = new XYFilterForm();
                xYFilterForm.ShowDialog();
                //when you close the XYFilterForm, it will close this window too
                this.Close();
            }
            else
            {
                //show an error message
                labelError.Text = "Load an image";
            }
            
        }

        
        //when you click the raibow button
        private void btnRaibow_Click(object sender, EventArgs e)
        {
            //do the filter in the class ImageFilters
            Bitmap bitmapImage = imageFilter.RainbowFilter(new Bitmap(picPreview.Image));
            //diplay the image with the filter
            picPreview.Image = bitmapImage;
            resultBitmap = bitmapImage;
        }

        //when you click the black and white button
        private void btnBlackWhite_Click(object sender, EventArgs e)
        {
            //do the filter in the class ImageFilters
            Bitmap bitmapImage = imageFilter.BlackWhite(new Bitmap(picPreview.Image));
            //diplay the image with the filter
            picPreview.Image = bitmapImage;
            resultBitmap = bitmapImage;
        }

        //when you click the miami button
        private void btnMiami_Click(object sender, EventArgs e)
        {
            //do the filter in the class ImageFilters
            Bitmap bitmapImage = imageFilter.MiamiFilter(new Bitmap(picPreview.Image), 1,1,10,1);
            //diplay the image with the filter
            picPreview.Image = bitmapImage;
            resultBitmap = bitmapImage;

        }
    }
}

