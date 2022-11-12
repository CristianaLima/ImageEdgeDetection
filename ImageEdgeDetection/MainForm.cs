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

namespace ImageEdgeDetection
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        public static Bitmap resultBitmap = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                resultBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = resultBitmap;
                
                
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            XYFilterForm xYFilterForm = new XYFilterForm();
            xYFilterForm.ShowDialog();
            this.Close();
            
        }

        

        private void btnRaibow_Click(object sender, EventArgs e)
        {
            Bitmap bitmapImage = ImageFilters.RainbowFilter(new Bitmap(picPreview.Image));
            picPreview.Image = bitmapImage;
            resultBitmap = bitmapImage;
        }

        private void btnBlackWhite_Click(object sender, EventArgs e)
        {
            Bitmap bitmapImage = ImageFilters.BlackWhite(new Bitmap(picPreview.Image));
            picPreview.Image = bitmapImage;
            resultBitmap = bitmapImage;
        }

        
    }
}

