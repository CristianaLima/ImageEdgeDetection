
using ImageEdgeDetection.BLL;
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
        
        // EdgeDetection interface
        private IFilterXY filterXY = new FilterXY();

        // DataAccess interface from BLL
        private IAccessData dataAccess = new AccessData();

        //result that XYFilterForm will pick
        public static Bitmap resultBitmap = null;

     
        public XYFilterForm()
        {
            InitializeComponent();
            //go search the image in the MainForm
            resultBitmap = MainForm.resultBitmap;
            //show the image
            originalPicBox.Image = resultBitmap;
        }

        //when you click on th save image button
        private void btnSaveNewImage_Click_1(object sender, EventArgs e)
        {
            //open yours files to save your image where you want
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

                dataAccess.SaveImage(resultBitmap, sfd.FileName);
            }
        }

        //when you click on apply X Y filters button
        private void btnApplyFilters_Click_1(object sender, EventArgs e)
        {
            //it hide the label error
            labelError.Text = " ";
            //see if you choose two filters
            if (xFilterBox.SelectedIndex != -1 && yFilterBox.SelectedIndex != -1)
            {
                //apply the filters
                resultBitmap= filterXY.filter(xFilterBox.SelectedIndex, yFilterBox.SelectedIndex, (Bitmap) originalPicBox.Image);

                resultPicBox.Image = resultBitmap;
            }
            else
            {
                //show an error message
                labelError.Text = "2 filters must be selected";
            }
        }
    }
}
