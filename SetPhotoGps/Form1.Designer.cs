namespace SetPhotoGps
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonFolderpath = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.listViewPhotosInFolder = new System.Windows.Forms.ListView();
            this.photoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpsLat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpsLon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSetGps = new System.Windows.Forms.Button();
            this.LatitudeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LongitudeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.textBoxSelectedFolderPath = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeViewFolderExplorer = new System.Windows.Forms.TreeView();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.webBrowserGoogleMaps = new System.Windows.Forms.WebBrowser();
            this.textBoxGpsCoordinatesOrCity = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeletePhoto = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.trackBarZoomGoogleMaps = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.LatitudeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongitudeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoomGoogleMaps)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFolderpath
            // 
            this.buttonFolderpath.Location = new System.Drawing.Point(7, 28);
            this.buttonFolderpath.Name = "buttonFolderpath";
            this.buttonFolderpath.Size = new System.Drawing.Size(133, 23);
            this.buttonFolderpath.TabIndex = 0;
            this.buttonFolderpath.Text = "select folder";
            this.buttonFolderpath.UseVisualStyleBackColor = true;
            this.buttonFolderpath.Click += new System.EventHandler(this.buttonFolderpath_Click);
            // 
            // listViewPhotosInFolder
            // 
            this.listViewPhotosInFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewPhotosInFolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.photoName,
            this.gpsLat,
            this.gpsLon});
            this.listViewPhotosInFolder.HideSelection = false;
            this.listViewPhotosInFolder.Location = new System.Drawing.Point(208, 81);
            this.listViewPhotosInFolder.Name = "listViewPhotosInFolder";
            this.listViewPhotosInFolder.Size = new System.Drawing.Size(496, 463);
            this.listViewPhotosInFolder.TabIndex = 1;
            this.listViewPhotosInFolder.UseCompatibleStateImageBehavior = false;
            this.listViewPhotosInFolder.View = System.Windows.Forms.View.Details;
            this.listViewPhotosInFolder.SelectedIndexChanged += new System.EventHandler(this.listViewPhotosInFolder_SelectedIndexChanged);
            this.listViewPhotosInFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewPhotosInFolder_KeyDown);
            this.listViewPhotosInFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewPhotosInFolder_MouseDoubleClick);
            // 
            // photoName
            // 
            this.photoName.Text = "Foto (jpg, jpeg)";
            this.photoName.Width = 299;
            // 
            // gpsLat
            // 
            this.gpsLat.Text = "latitude (Lat)";
            this.gpsLat.Width = 100;
            // 
            // gpsLon
            // 
            this.gpsLon.Text = "Longitude (Lon)";
            this.gpsLon.Width = 152;
            // 
            // buttonSetGps
            // 
            this.buttonSetGps.Location = new System.Drawing.Point(509, 3);
            this.buttonSetGps.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetGps.Name = "buttonSetGps";
            this.buttonSetGps.Size = new System.Drawing.Size(195, 23);
            this.buttonSetGps.TabIndex = 6;
            this.buttonSetGps.Text = "add GPS to image(s)";
            this.buttonSetGps.UseVisualStyleBackColor = true;
            this.buttonSetGps.Click += new System.EventHandler(this.buttonSetGps_Click);
            // 
            // LatitudeNumericUpDown
            // 
            this.LatitudeNumericUpDown.DecimalPlaces = 5;
            this.LatitudeNumericUpDown.Location = new System.Drawing.Point(509, 56);
            this.LatitudeNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.LatitudeNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.LatitudeNumericUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.LatitudeNumericUpDown.Name = "LatitudeNumericUpDown";
            this.LatitudeNumericUpDown.Size = new System.Drawing.Size(99, 20);
            this.LatitudeNumericUpDown.TabIndex = 7;
            // 
            // LongitudeNumericUpDown
            // 
            this.LongitudeNumericUpDown.DecimalPlaces = 5;
            this.LongitudeNumericUpDown.Location = new System.Drawing.Point(612, 56);
            this.LongitudeNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.LongitudeNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.LongitudeNumericUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.LongitudeNumericUpDown.Name = "LongitudeNumericUpDown";
            this.LongitudeNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this.LongitudeNumericUpDown.TabIndex = 8;
            // 
            // textBoxSelectedFolderPath
            // 
            this.textBoxSelectedFolderPath.Location = new System.Drawing.Point(7, 56);
            this.textBoxSelectedFolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSelectedFolderPath.Name = "textBoxSelectedFolderPath";
            this.textBoxSelectedFolderPath.Size = new System.Drawing.Size(498, 20);
            this.textBoxSelectedFolderPath.TabIndex = 9;
            this.textBoxSelectedFolderPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSelectedFolderPath_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            // 
            // treeViewFolderExplorer
            // 
            this.treeViewFolderExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewFolderExplorer.ImageIndex = 0;
            this.treeViewFolderExplorer.ImageList = this.imageList1;
            this.treeViewFolderExplorer.Location = new System.Drawing.Point(7, 80);
            this.treeViewFolderExplorer.Name = "treeViewFolderExplorer";
            this.treeViewFolderExplorer.SelectedImageIndex = 0;
            this.treeViewFolderExplorer.Size = new System.Drawing.Size(195, 464);
            this.treeViewFolderExplorer.TabIndex = 11;
            this.treeViewFolderExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxThumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxThumbnail.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(381, 254);
            this.pictureBoxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxThumbnail.TabIndex = 3;
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // webBrowserGoogleMaps
            // 
            this.webBrowserGoogleMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserGoogleMaps.Location = new System.Drawing.Point(3, 263);
            this.webBrowserGoogleMaps.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGoogleMaps.Name = "webBrowserGoogleMaps";
            this.webBrowserGoogleMaps.Size = new System.Drawing.Size(381, 255);
            this.webBrowserGoogleMaps.TabIndex = 12;
            // 
            // textBoxGpsCoordinatesOrCity
            // 
            this.textBoxGpsCoordinatesOrCity.Location = new System.Drawing.Point(509, 28);
            this.textBoxGpsCoordinatesOrCity.Name = "textBoxGpsCoordinatesOrCity";
            this.textBoxGpsCoordinatesOrCity.Size = new System.Drawing.Size(195, 20);
            this.textBoxGpsCoordinatesOrCity.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textBoxGpsCoordinatesOrCity, resources.GetString("textBoxGpsCoordinatesOrCity.ToolTip"));
            this.textBoxGpsCoordinatesOrCity.TextChanged += new System.EventHandler(this.textBoxGpsCoordinates_TextChanged);
            this.textBoxGpsCoordinatesOrCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxGpsCoordinates_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.webBrowserGoogleMaps, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxThumbnail, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(710, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 521);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "City or \r\nGPS-String";
            // 
            // buttonDeletePhoto
            // 
            this.buttonDeletePhoto.ForeColor = System.Drawing.Color.Red;
            this.buttonDeletePhoto.Location = new System.Drawing.Point(145, 27);
            this.buttonDeletePhoto.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeletePhoto.Name = "buttonDeletePhoto";
            this.buttonDeletePhoto.Size = new System.Drawing.Size(98, 23);
            this.buttonDeletePhoto.TabIndex = 16;
            this.buttonDeletePhoto.Text = "delete image";
            this.buttonDeletePhoto.UseVisualStyleBackColor = true;
            this.buttonDeletePhoto.Click += new System.EventHandler(this.buttonDeletePhoto_Click);
            // 
            // trackBarZoomGoogleMaps
            // 
            this.trackBarZoomGoogleMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarZoomGoogleMaps.Location = new System.Drawing.Point(713, 524);
            this.trackBarZoomGoogleMaps.Maximum = 23;
            this.trackBarZoomGoogleMaps.Name = "trackBarZoomGoogleMaps";
            this.trackBarZoomGoogleMaps.Size = new System.Drawing.Size(381, 45);
            this.trackBarZoomGoogleMaps.TabIndex = 18;
            this.trackBarZoomGoogleMaps.Value = 14;
            this.trackBarZoomGoogleMaps.Scroll += new System.EventHandler(this.trackBarZoomGoogleMaps_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 548);
            this.Controls.Add(this.trackBarZoomGoogleMaps);
            this.Controls.Add(this.buttonDeletePhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBoxGpsCoordinatesOrCity);
            this.Controls.Add(this.treeViewFolderExplorer);
            this.Controls.Add(this.textBoxSelectedFolderPath);
            this.Controls.Add(this.LongitudeNumericUpDown);
            this.Controls.Add(this.LatitudeNumericUpDown);
            this.Controls.Add(this.buttonSetGps);
            this.Controls.Add(this.listViewPhotosInFolder);
            this.Controls.Add(this.buttonFolderpath);
            this.Name = "Form1";
            this.Text = "Add GPS coordinates to jpg images";
            ((System.ComponentModel.ISupportInitialize)(this.LatitudeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongitudeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoomGoogleMaps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFolderpath;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ListView listViewPhotosInFolder;
        private System.Windows.Forms.ColumnHeader photoName;
        private System.Windows.Forms.ColumnHeader gpsLat;
        private System.Windows.Forms.ColumnHeader gpsLon;
        private System.Windows.Forms.Button buttonSetGps;
        private System.Windows.Forms.NumericUpDown LatitudeNumericUpDown;
        private System.Windows.Forms.NumericUpDown LongitudeNumericUpDown;
        private System.Windows.Forms.TextBox textBoxSelectedFolderPath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeViewFolderExplorer;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.WebBrowser webBrowserGoogleMaps;
        private System.Windows.Forms.TextBox textBoxGpsCoordinatesOrCity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeletePhoto;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TrackBar trackBarZoomGoogleMaps;
    }
}

