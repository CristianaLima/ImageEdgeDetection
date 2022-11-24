
namespace ImageEdgeDetection
{
    partial class XYFilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalPicBox = new System.Windows.Forms.PictureBox();
            this.resultPicBox = new System.Windows.Forms.PictureBox();
            this.labelError = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveNewImage = new System.Windows.Forms.Button();
            this.xFilterBox = new System.Windows.Forms.ComboBox();
            this.yFilterBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPicBox
            // 
            this.originalPicBox.BackColor = System.Drawing.Color.Silver;
            this.originalPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.originalPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPicBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.originalPicBox.Location = new System.Drawing.Point(26, 134);
            this.originalPicBox.Name = "originalPicBox";
            this.originalPicBox.Size = new System.Drawing.Size(600, 600);
            this.originalPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPicBox.TabIndex = 0;
            this.originalPicBox.TabStop = false;
            // 
            // resultPicBox
            // 
            this.resultPicBox.BackColor = System.Drawing.Color.Silver;
            this.resultPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.resultPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPicBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.resultPicBox.Location = new System.Drawing.Point(836, 134);
            this.resultPicBox.Name = "resultPicBox";
            this.resultPicBox.Size = new System.Drawing.Size(600, 600);
            this.resultPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultPicBox.TabIndex = 1;
            this.resultPicBox.TabStop = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(658, 228);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(16, 23);
            this.labelError.TabIndex = 34;
            this.labelError.Text = " ";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Location = new System.Drawing.Point(661, 576);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(136, 38);
            this.btnApplyFilters.TabIndex = 33;
            this.btnApplyFilters.Text = "Apply X Y Filters";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Y Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "X Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(829, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 38);
            this.label3.TabIndex = 35;
            this.label3.Text = "Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 38);
            this.label4.TabIndex = 36;
            this.label4.Text = "Preview";
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewImage.Location = new System.Drawing.Point(662, 688);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(136, 46);
            this.btnSaveNewImage.TabIndex = 37;
            this.btnSaveNewImage.Text = "Save Image";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.btnSaveNewImage_Click_1);
            // 
            // xFilterBox
            // 
            this.xFilterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xFilterBox.FormattingEnabled = true;
            this.xFilterBox.Items.AddRange(new object[] {
            "Laplacian3x3",
            "Laplacian5x5",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.xFilterBox.Location = new System.Drawing.Point(661, 291);
            this.xFilterBox.Name = "xFilterBox";
            this.xFilterBox.Size = new System.Drawing.Size(137, 24);
            this.xFilterBox.TabIndex = 38;
            this.xFilterBox.SelectedIndexChanged += new System.EventHandler(this.xFilterBox_SelectedIndexChanged);
            // 
            // yFilterBox
            // 
            this.yFilterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yFilterBox.FormattingEnabled = true;
            this.yFilterBox.Items.AddRange(new object[] {
            "Laplacian3x3",
            "Laplacian5x5",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.yFilterBox.Location = new System.Drawing.Point(662, 451);
            this.yFilterBox.Name = "yFilterBox";
            this.yFilterBox.Size = new System.Drawing.Size(137, 24);
            this.yFilterBox.TabIndex = 39;
            // 
            // XYFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 763);
            this.Controls.Add(this.yFilterBox);
            this.Controls.Add(this.xFilterBox);
            this.Controls.Add(this.btnSaveNewImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.btnApplyFilters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultPicBox);
            this.Controls.Add(this.originalPicBox);
            this.Name = "XYFilterForm";
            this.Text = "XYFilterForm";
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPicBox;
        private System.Windows.Forms.PictureBox resultPicBox;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.ComboBox xFilterBox;
        private System.Windows.Forms.ComboBox yFilterBox;
    }
}