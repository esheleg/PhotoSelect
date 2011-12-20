namespace PhotoSelectGui
{
    partial class MainPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPS));
            this.PathFrame = new System.Windows.Forms.GroupBox();
            this.numPicsLbl = new System.Windows.Forms.Label();
            this.numLbl = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.browseLbl = new System.Windows.Forms.Label();
            this.photosPaths = new System.Windows.Forms.ListBox();
            this.textpath = new System.Windows.Forms.TextBox();
            this.doneStepOneLbl = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.browseRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.doneStepOneRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.FilterPath = new System.Windows.Forms.GroupBox();
            this.similarPicChckBox = new System.Windows.Forms.CheckBox();
            this.badContrastChckBox = new System.Windows.Forms.CheckBox();
            this.partitialChckBox = new System.Windows.Forms.CheckBox();
            this.identicalPicsChckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.doneStepTwoLbl = new System.Windows.Forms.Label();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.doneStepTwoRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.progressFr = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelProgressLbl = new System.Windows.Forms.Label();
            this.DTprogressBar = new System.Windows.Forms.ProgressBar();
            this.shapeContainer4 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.frameMovementTimer = new System.Windows.Forms.Timer(this.components);
            this.stepOneLbl = new System.Windows.Forms.Label();
            this.stepTwoLbl = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBarTimer = new System.Windows.Forms.Timer(this.components);
            this.stepThreeLbl = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.stepThreeRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.stepTwoRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.stepOneRect = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.bitExactFr = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelname = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.labelLoc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.createdemo = new System.Windows.Forms.Button();
            this.buttonAbortSelect = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.MatchesList = new System.Windows.Forms.CheckedListBox();
            this.PictureResult = new System.Windows.Forms.PictureBox();
            this.shapeContainer5 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.PathFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.FilterPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.progressFr.SuspendLayout();
            this.bitExactFr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureResult)).BeginInit();
            this.SuspendLayout();
            // 
            // PathFrame
            // 
            this.PathFrame.BackColor = System.Drawing.SystemColors.HighlightText;
            this.PathFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PathFrame.Controls.Add(this.numPicsLbl);
            this.PathFrame.Controls.Add(this.numLbl);
            this.PathFrame.Controls.Add(this.pictureBox);
            this.PathFrame.Controls.Add(this.browseLbl);
            this.PathFrame.Controls.Add(this.photosPaths);
            this.PathFrame.Controls.Add(this.textpath);
            this.PathFrame.Controls.Add(this.doneStepOneLbl);
            this.PathFrame.Controls.Add(this.shapeContainer2);
            this.PathFrame.ForeColor = System.Drawing.Color.Cornsilk;
            this.PathFrame.Location = new System.Drawing.Point(28, 572);
            this.PathFrame.Name = "PathFrame";
            this.PathFrame.Size = new System.Drawing.Size(688, 380);
            this.PathFrame.TabIndex = 1;
            this.PathFrame.TabStop = false;
            // 
            // numPicsLbl
            // 
            this.numPicsLbl.AutoSize = true;
            this.numPicsLbl.BackColor = System.Drawing.Color.Green;
            this.numPicsLbl.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numPicsLbl.Location = new System.Drawing.Point(389, 321);
            this.numPicsLbl.Name = "numPicsLbl";
            this.numPicsLbl.Size = new System.Drawing.Size(138, 37);
            this.numPicsLbl.TabIndex = 13;
            this.numPicsLbl.Text = "Pictures";
            this.numPicsLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numLbl
            // 
            this.numLbl.AutoSize = true;
            this.numLbl.BackColor = System.Drawing.Color.Green;
            this.numLbl.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numLbl.Location = new System.Drawing.Point(286, 321);
            this.numLbl.Name = "numLbl";
            this.numLbl.Size = new System.Drawing.Size(34, 37);
            this.numLbl.TabIndex = 12;
            this.numLbl.Text = "0";
            this.numLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(286, 120);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(293, 190);
            this.pictureBox.TabIndex = 11;
            this.pictureBox.TabStop = false;
            // 
            // browseLbl
            // 
            this.browseLbl.AutoSize = true;
            this.browseLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.browseLbl.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.browseLbl.Location = new System.Drawing.Point(70, 43);
            this.browseLbl.Name = "browseLbl";
            this.browseLbl.Size = new System.Drawing.Size(129, 37);
            this.browseLbl.TabIndex = 10;
            this.browseLbl.Text = "Browse";
            this.browseLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.browseLbl.Click += new System.EventHandler(this.browseLbl_Click);
            // 
            // photosPaths
            // 
            this.photosPaths.FormattingEnabled = true;
            this.photosPaths.Location = new System.Drawing.Point(14, 120);
            this.photosPaths.Name = "photosPaths";
            this.photosPaths.Size = new System.Drawing.Size(266, 238);
            this.photosPaths.TabIndex = 9;
            this.photosPaths.SelectedIndexChanged += new System.EventHandler(this.photosPaths_SelectedIndexChanged);
            // 
            // textpath
            // 
            this.textpath.Location = new System.Drawing.Point(14, 94);
            this.textpath.Name = "textpath";
            this.textpath.ReadOnly = true;
            this.textpath.Size = new System.Drawing.Size(565, 20);
            this.textpath.TabIndex = 6;
            // 
            // doneStepOneLbl
            // 
            this.doneStepOneLbl.AutoSize = true;
            this.doneStepOneLbl.BackColor = System.Drawing.SystemColors.Highlight;
            this.doneStepOneLbl.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.doneStepOneLbl.Location = new System.Drawing.Point(576, 326);
            this.doneStepOneLbl.Name = "doneStepOneLbl";
            this.doneStepOneLbl.Size = new System.Drawing.Size(98, 37);
            this.doneStepOneLbl.TabIndex = 5;
            this.doneStepOneLbl.Text = "Done";
            this.doneStepOneLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.doneStepOneLbl.Click += new System.EventHandler(this.doneStepOneLbl_Click);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.browseRect,
            this.doneStepOneRect});
            this.shapeContainer2.Size = new System.Drawing.Size(682, 361);
            this.shapeContainer2.TabIndex = 7;
            this.shapeContainer2.TabStop = false;
            // 
            // browseRect
            // 
            this.browseRect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.browseRect.BackColor = System.Drawing.Color.Maroon;
            this.browseRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.browseRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.browseRect.BorderColor = System.Drawing.SystemColors.Desktop;
            this.browseRect.CornerRadius = 8;
            this.browseRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseRect.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.browseRect.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.browseRect.Location = new System.Drawing.Point(11, 24);
            this.browseRect.Name = "browseRect";
            this.browseRect.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.browseRect.Size = new System.Drawing.Size(249, 44);
            // 
            // doneStepOneRect
            // 
            this.doneStepOneRect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.doneStepOneRect.BackColor = System.Drawing.Color.Maroon;
            this.doneStepOneRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.doneStepOneRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.doneStepOneRect.BorderColor = System.Drawing.SystemColors.Desktop;
            this.doneStepOneRect.CornerRadius = 8;
            this.doneStepOneRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doneStepOneRect.FillColor = System.Drawing.SystemColors.Highlight;
            this.doneStepOneRect.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.doneStepOneRect.Location = new System.Drawing.Point(559, 300);
            this.doneStepOneRect.Name = "doneStepOneRect";
            this.doneStepOneRect.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.doneStepOneRect.Size = new System.Drawing.Size(119, 55);
            // 
            // FilterPath
            // 
            this.FilterPath.BackColor = System.Drawing.SystemColors.HighlightText;
            this.FilterPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FilterPath.Controls.Add(this.similarPicChckBox);
            this.FilterPath.Controls.Add(this.badContrastChckBox);
            this.FilterPath.Controls.Add(this.partitialChckBox);
            this.FilterPath.Controls.Add(this.identicalPicsChckBox);
            this.FilterPath.Controls.Add(this.pictureBox1);
            this.FilterPath.Controls.Add(this.pictureBox5);
            this.FilterPath.Controls.Add(this.label10);
            this.FilterPath.Controls.Add(this.label9);
            this.FilterPath.Controls.Add(this.label8);
            this.FilterPath.Controls.Add(this.label7);
            this.FilterPath.Controls.Add(this.pictureBox4);
            this.FilterPath.Controls.Add(this.pictureBox3);
            this.FilterPath.Controls.Add(this.pictureBox2);
            this.FilterPath.Controls.Add(this.label5);
            this.FilterPath.Controls.Add(this.doneStepTwoLbl);
            this.FilterPath.Controls.Add(this.shapeContainer3);
            this.FilterPath.ForeColor = System.Drawing.Color.Cornsilk;
            this.FilterPath.Location = new System.Drawing.Point(36, 588);
            this.FilterPath.Name = "FilterPath";
            this.FilterPath.Size = new System.Drawing.Size(703, 380);
            this.FilterPath.TabIndex = 4;
            this.FilterPath.TabStop = false;
            this.FilterPath.Visible = false;
            // 
            // similarPicChckBox
            // 
            this.similarPicChckBox.AutoSize = true;
            this.similarPicChckBox.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.similarPicChckBox.Location = new System.Drawing.Point(531, 235);
            this.similarPicChckBox.Name = "similarPicChckBox";
            this.similarPicChckBox.Size = new System.Drawing.Size(15, 14);
            this.similarPicChckBox.TabIndex = 30;
            this.similarPicChckBox.UseVisualStyleBackColor = true;
            this.similarPicChckBox.CheckedChanged += new System.EventHandler(this.similarPicChckBox_CheckedChanged);
            // 
            // badContrastChckBox
            // 
            this.badContrastChckBox.AutoSize = true;
            this.badContrastChckBox.Location = new System.Drawing.Point(386, 236);
            this.badContrastChckBox.Name = "badContrastChckBox";
            this.badContrastChckBox.Size = new System.Drawing.Size(15, 14);
            this.badContrastChckBox.TabIndex = 28;
            this.badContrastChckBox.UseVisualStyleBackColor = true;
            this.badContrastChckBox.CheckedChanged += new System.EventHandler(this.badContrastChckBox_CheckedChanged);
            // 
            // partitialChckBox
            // 
            this.partitialChckBox.AutoSize = true;
            this.partitialChckBox.Location = new System.Drawing.Point(248, 236);
            this.partitialChckBox.Name = "partitialChckBox";
            this.partitialChckBox.Size = new System.Drawing.Size(80, 17);
            this.partitialChckBox.TabIndex = 27;
            this.partitialChckBox.Text = "checkBox2";
            this.partitialChckBox.UseVisualStyleBackColor = true;
            this.partitialChckBox.CheckedChanged += new System.EventHandler(this.partitialChckBox_CheckedChanged);
            // 
            // identicalPicsChckBox
            // 
            this.identicalPicsChckBox.AutoSize = true;
            this.identicalPicsChckBox.Location = new System.Drawing.Point(97, 235);
            this.identicalPicsChckBox.Name = "identicalPicsChckBox";
            this.identicalPicsChckBox.Size = new System.Drawing.Size(80, 17);
            this.identicalPicsChckBox.TabIndex = 26;
            this.identicalPicsChckBox.Text = "checkBox1";
            this.identicalPicsChckBox.UseVisualStyleBackColor = true;
            this.identicalPicsChckBox.CheckedChanged += new System.EventHandler(this.identicalPicsChckBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PhotoSelectGui.Properties.Resources.smile33;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(76, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 83);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::PhotoSelectGui.Properties.Resources.smile33;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(51, 105);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(119, 113);
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(207, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "חסימה חלקית";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(334, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "תמונות מטושטשות";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(517, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "דומות";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(69, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "תמונות זהות\r\n";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::PhotoSelectGui.Properties.Resources.dsones_similar;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = global::PhotoSelectGui.Properties.Resources.dsones_similar;
            this.pictureBox4.Location = new System.Drawing.Point(480, 105);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(119, 113);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PhotoSelectGui.Properties.Resources.eye_light_11;
            this.pictureBox3.Location = new System.Drawing.Point(338, 105);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(119, 113);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::PhotoSelectGui.Properties.Resources.switzerland_mountain_lake;
            this.pictureBox2.Location = new System.Drawing.Point(197, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "בחר תכנית עבודה";
            // 
            // doneStepTwoLbl
            // 
            this.doneStepTwoLbl.AutoSize = true;
            this.doneStepTwoLbl.BackColor = System.Drawing.SystemColors.Highlight;
            this.doneStepTwoLbl.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.doneStepTwoLbl.Location = new System.Drawing.Point(582, 327);
            this.doneStepTwoLbl.Name = "doneStepTwoLbl";
            this.doneStepTwoLbl.Size = new System.Drawing.Size(98, 37);
            this.doneStepTwoLbl.TabIndex = 5;
            this.doneStepTwoLbl.Text = "Done";
            this.doneStepTwoLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.doneStepTwoLbl.Click += new System.EventHandler(this.doneStepTwoLbl_Click);
            // 
            // shapeContainer3
            // 
            this.shapeContainer3.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer3.Name = "shapeContainer3";
            this.shapeContainer3.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.doneStepTwoRect});
            this.shapeContainer3.Size = new System.Drawing.Size(697, 361);
            this.shapeContainer3.TabIndex = 7;
            this.shapeContainer3.TabStop = false;
            // 
            // doneStepTwoRect
            // 
            this.doneStepTwoRect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.doneStepTwoRect.BackColor = System.Drawing.Color.Maroon;
            this.doneStepTwoRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.doneStepTwoRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.doneStepTwoRect.BorderColor = System.Drawing.SystemColors.Desktop;
            this.doneStepTwoRect.CornerRadius = 8;
            this.doneStepTwoRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doneStepTwoRect.FillColor = System.Drawing.SystemColors.Highlight;
            this.doneStepTwoRect.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.doneStepTwoRect.Location = new System.Drawing.Point(565, 300);
            this.doneStepTwoRect.Name = "doneStepTwoRect";
            this.doneStepTwoRect.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.doneStepTwoRect.Size = new System.Drawing.Size(129, 54);
            // 
            // progressFr
            // 
            this.progressFr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.progressFr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.progressFr.Controls.Add(this.label2);
            this.progressFr.Controls.Add(this.cancelProgressLbl);
            this.progressFr.Controls.Add(this.DTprogressBar);
            this.progressFr.Controls.Add(this.shapeContainer4);
            this.progressFr.ForeColor = System.Drawing.Color.Cornsilk;
            this.progressFr.Location = new System.Drawing.Point(25, 550);
            this.progressFr.Name = "progressFr";
            this.progressFr.Size = new System.Drawing.Size(688, 380);
            this.progressFr.TabIndex = 14;
            this.progressFr.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(86, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Building Data Base...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cancelProgressLbl
            // 
            this.cancelProgressLbl.AutoSize = true;
            this.cancelProgressLbl.BackColor = System.Drawing.Color.Red;
            this.cancelProgressLbl.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cancelProgressLbl.Location = new System.Drawing.Point(552, 327);
            this.cancelProgressLbl.Name = "cancelProgressLbl";
            this.cancelProgressLbl.Size = new System.Drawing.Size(122, 37);
            this.cancelProgressLbl.TabIndex = 6;
            this.cancelProgressLbl.Text = "Cancel";
            this.cancelProgressLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelProgressLbl.Click += new System.EventHandler(this.cancelProgressLbl_Click);
            // 
            // DTprogressBar
            // 
            this.DTprogressBar.Location = new System.Drawing.Point(93, 84);
            this.DTprogressBar.Name = "DTprogressBar";
            this.DTprogressBar.Size = new System.Drawing.Size(504, 85);
            this.DTprogressBar.TabIndex = 0;
            // 
            // shapeContainer4
            // 
            this.shapeContainer4.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer4.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer4.Name = "shapeContainer4";
            this.shapeContainer4.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer4.Size = new System.Drawing.Size(682, 361);
            this.shapeContainer4.TabIndex = 7;
            this.shapeContainer4.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape1.BackColor = System.Drawing.Color.Maroon;
            this.rectangleShape1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.SystemColors.Desktop;
            this.rectangleShape1.CornerRadius = 8;
            this.rectangleShape1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangleShape1.FillColor = System.Drawing.Color.Red;
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(541, 299);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rectangleShape1.Size = new System.Drawing.Size(136, 55);
            // 
            // frameMovementTimer
            // 
            this.frameMovementTimer.Interval = 10;
            this.frameMovementTimer.Tick += new System.EventHandler(this.frameMovementTimer_Tick);
            // 
            // stepOneLbl
            // 
            this.stepOneLbl.AutoSize = true;
            this.stepOneLbl.BackColor = System.Drawing.Color.White;
            this.stepOneLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepOneLbl.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepOneLbl.Location = new System.Drawing.Point(61, 123);
            this.stepOneLbl.Name = "stepOneLbl";
            this.stepOneLbl.Size = new System.Drawing.Size(120, 44);
            this.stepOneLbl.TabIndex = 2;
            this.stepOneLbl.Text = "Step One";
            this.stepOneLbl.Click += new System.EventHandler(this.stepOneLbl_Click);
            // 
            // stepTwoLbl
            // 
            this.stepTwoLbl.AutoSize = true;
            this.stepTwoLbl.BackColor = System.Drawing.Color.White;
            this.stepTwoLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepTwoLbl.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepTwoLbl.Location = new System.Drawing.Point(233, 123);
            this.stepTwoLbl.Name = "stepTwoLbl";
            this.stepTwoLbl.Size = new System.Drawing.Size(115, 44);
            this.stepTwoLbl.TabIndex = 3;
            this.stepTwoLbl.Text = "Step Two";
            this.stepTwoLbl.Click += new System.EventHandler(this.stepTwoLbl_Click);
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Tick += new System.EventHandler(this.progressBarTimer_Tick);
            // 
            // stepThreeLbl
            // 
            this.stepThreeLbl.AutoSize = true;
            this.stepThreeLbl.BackColor = System.Drawing.Color.White;
            this.stepThreeLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepThreeLbl.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepThreeLbl.Location = new System.Drawing.Point(393, 123);
            this.stepThreeLbl.Name = "stepThreeLbl";
            this.stepThreeLbl.Size = new System.Drawing.Size(127, 44);
            this.stepThreeLbl.TabIndex = 15;
            this.stepThreeLbl.Text = "Step Three";
            this.stepThreeLbl.Click += new System.EventHandler(this.stepThreeLbl_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.stepThreeRect,
            this.stepTwoRect,
            this.stepOneRect});
            this.shapeContainer1.Size = new System.Drawing.Size(781, 606);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // stepThreeRect
            // 
            this.stepThreeRect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepThreeRect.BackColor = System.Drawing.Color.Maroon;
            this.stepThreeRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stepThreeRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.stepThreeRect.BorderColor = System.Drawing.SystemColors.Desktop;
            this.stepThreeRect.CornerRadius = 8;
            this.stepThreeRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepThreeRect.FillColor = System.Drawing.Color.White;
            this.stepThreeRect.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.stepThreeRect.Location = new System.Drawing.Point(386, 119);
            this.stepThreeRect.Name = "stepThreeRect";
            this.stepThreeRect.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stepThreeRect.Size = new System.Drawing.Size(150, 50);
            // 
            // stepTwoRect
            // 
            this.stepTwoRect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepTwoRect.BackColor = System.Drawing.Color.Maroon;
            this.stepTwoRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stepTwoRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.stepTwoRect.BorderColor = System.Drawing.SystemColors.Desktop;
            this.stepTwoRect.CornerRadius = 8;
            this.stepTwoRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepTwoRect.FillColor = System.Drawing.Color.White;
            this.stepTwoRect.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.stepTwoRect.Location = new System.Drawing.Point(217, 118);
            this.stepTwoRect.Name = "stepTwoRect";
            this.stepTwoRect.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stepTwoRect.Size = new System.Drawing.Size(150, 50);
            // 
            // stepOneRect
            // 
            this.stepOneRect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepOneRect.BackColor = System.Drawing.Color.Maroon;
            this.stepOneRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stepOneRect.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.stepOneRect.BorderColor = System.Drawing.SystemColors.Desktop;
            this.stepOneRect.CornerRadius = 8;
            this.stepOneRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stepOneRect.FillColor = System.Drawing.Color.White;
            this.stepOneRect.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.stepOneRect.Location = new System.Drawing.Point(51, 118);
            this.stepOneRect.Name = "stepOneRect";
            this.stepOneRect.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stepOneRect.Size = new System.Drawing.Size(150, 50);
            // 
            // bitExactFr
            // 
            this.bitExactFr.BackColor = System.Drawing.Color.GhostWhite;
            this.bitExactFr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bitExactFr.Controls.Add(this.label11);
            this.bitExactFr.Controls.Add(this.labelname);
            this.bitExactFr.Controls.Add(this.labelRes);
            this.bitExactFr.Controls.Add(this.labelLoc);
            this.bitExactFr.Controls.Add(this.button1);
            this.bitExactFr.Controls.Add(this.label6);
            this.bitExactFr.Controls.Add(this.label4);
            this.bitExactFr.Controls.Add(this.label3);
            this.bitExactFr.Controls.Add(this.label1);
            this.bitExactFr.Controls.Add(this.buttonDeleteSelected);
            this.bitExactFr.Controls.Add(this.createdemo);
            this.bitExactFr.Controls.Add(this.buttonAbortSelect);
            this.bitExactFr.Controls.Add(this.buttonSelectAll);
            this.bitExactFr.Controls.Add(this.buttonBack);
            this.bitExactFr.Controls.Add(this.buttonForward);
            this.bitExactFr.Controls.Add(this.MatchesList);
            this.bitExactFr.Controls.Add(this.PictureResult);
            this.bitExactFr.Controls.Add(this.shapeContainer5);
            this.bitExactFr.ForeColor = System.Drawing.Color.Cornsilk;
            this.bitExactFr.Location = new System.Drawing.Point(69, 187);
            this.bitExactFr.Name = "bitExactFr";
            this.bitExactFr.Size = new System.Drawing.Size(688, 395);
            this.bitExactFr.TabIndex = 16;
            this.bitExactFr.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(217, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 30);
            this.label11.TabIndex = 27;
            this.label11.Text = "Bit-eXact Results";
            // 
            // labelname
            // 
            this.labelname.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelname.Location = new System.Drawing.Point(231, 58);
            this.labelname.Name = "labelname";
            this.labelname.Size = new System.Drawing.Size(312, 18);
            this.labelname.TabIndex = 26;
            this.labelname.Text = "פרטים";
            // 
            // labelRes
            // 
            this.labelRes.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelRes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelRes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelRes.Location = new System.Drawing.Point(231, 123);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(312, 18);
            this.labelRes.TabIndex = 26;
            this.labelRes.Text = "פרטים";
            // 
            // labelLoc
            // 
            this.labelLoc.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelLoc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelLoc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelLoc.Location = new System.Drawing.Point(231, 92);
            this.labelLoc.Name = "labelLoc";
            this.labelLoc.Size = new System.Drawing.Size(312, 18);
            this.labelLoc.TabIndex = 25;
            this.labelLoc.Text = "פרטים";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(525, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 31);
            this.button1.TabIndex = 24;
            this.button1.Text = "deleteList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Highlight;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(566, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "רזולוציה";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Highlight;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(566, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "מיקום";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Highlight;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(566, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "שם התמונה";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(506, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "פרטי התמונה";
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.Enabled = false;
            this.buttonDeleteSelected.ForeColor = System.Drawing.Color.Black;
            this.buttonDeleteSelected.Location = new System.Drawing.Point(25, 349);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(74, 31);
            this.buttonDeleteSelected.TabIndex = 19;
            this.buttonDeleteSelected.Text = "מחיקה";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click_1);
            // 
            // createdemo
            // 
            this.createdemo.ForeColor = System.Drawing.Color.Black;
            this.createdemo.Location = new System.Drawing.Point(595, 349);
            this.createdemo.Name = "createdemo";
            this.createdemo.Size = new System.Drawing.Size(64, 31);
            this.createdemo.TabIndex = 18;
            this.createdemo.Text = "צור דמו";
            this.createdemo.UseVisualStyleBackColor = true;
            this.createdemo.Click += new System.EventHandler(this.createdemo_Click_1);
            // 
            // buttonAbortSelect
            // 
            this.buttonAbortSelect.ForeColor = System.Drawing.Color.Black;
            this.buttonAbortSelect.Location = new System.Drawing.Point(103, 349);
            this.buttonAbortSelect.Name = "buttonAbortSelect";
            this.buttonAbortSelect.Size = new System.Drawing.Size(74, 31);
            this.buttonAbortSelect.TabIndex = 16;
            this.buttonAbortSelect.Text = "בטל בחירה";
            this.buttonAbortSelect.UseVisualStyleBackColor = true;
            this.buttonAbortSelect.Click += new System.EventHandler(this.buttonAbortSelect_Click_1);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.ForeColor = System.Drawing.Color.Black;
            this.buttonSelectAll.Location = new System.Drawing.Point(181, 349);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(74, 31);
            this.buttonSelectAll.TabIndex = 15;
            this.buttonSelectAll.Text = "בחר הכל";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click_1);
            // 
            // buttonBack
            // 
            this.buttonBack.ForeColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(147, 174);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(64, 30);
            this.buttonBack.TabIndex = 14;
            this.buttonBack.Text = "אחורה";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonForward
            // 
            this.buttonForward.ForeColor = System.Drawing.Color.Black;
            this.buttonForward.Location = new System.Drawing.Point(25, 174);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(64, 30);
            this.buttonForward.TabIndex = 13;
            this.buttonForward.Text = "הבא";
            this.buttonForward.UseVisualStyleBackColor = true;
            // 
            // MatchesList
            // 
            this.MatchesList.FormattingEnabled = true;
            this.MatchesList.Location = new System.Drawing.Point(24, 210);
            this.MatchesList.Name = "MatchesList";
            this.MatchesList.Size = new System.Drawing.Size(636, 139);
            this.MatchesList.TabIndex = 12;
            this.MatchesList.SelectedIndexChanged += new System.EventHandler(this.MatchesList_SelectedIndexChanged_1);
            // 
            // PictureResult
            // 
            this.PictureResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureResult.Location = new System.Drawing.Point(25, 19);
            this.PictureResult.Name = "PictureResult";
            this.PictureResult.Size = new System.Drawing.Size(186, 148);
            this.PictureResult.TabIndex = 11;
            this.PictureResult.TabStop = false;
            // 
            // shapeContainer5
            // 
            this.shapeContainer5.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer5.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer5.Name = "shapeContainer5";
            this.shapeContainer5.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2});
            this.shapeContainer5.Size = new System.Drawing.Size(682, 376);
            this.shapeContainer5.TabIndex = 7;
            this.shapeContainer5.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rectangleShape2.BackColor = System.Drawing.SystemColors.Highlight;
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.Location = new System.Drawing.Point(216, 3);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(439, 181);
            // 
            // MainPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(781, 606);
            this.Controls.Add(this.bitExactFr);
            this.Controls.Add(this.progressFr);
            this.Controls.Add(this.FilterPath);
            this.Controls.Add(this.stepThreeLbl);
            this.Controls.Add(this.stepTwoLbl);
            this.Controls.Add(this.stepOneLbl);
            this.Controls.Add(this.PathFrame);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MainPS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoSelect";
            this.Load += new System.EventHandler(this.MainPS_Load);
            this.PathFrame.ResumeLayout(false);
            this.PathFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.FilterPath.ResumeLayout(false);
            this.FilterPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.progressFr.ResumeLayout(false);
            this.progressFr.PerformLayout();
            this.bitExactFr.ResumeLayout(false);
            this.bitExactFr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PathFrame;
        private System.Windows.Forms.Label doneStepOneLbl;
        private System.Windows.Forms.Timer frameMovementTimer;
        private System.Windows.Forms.TextBox textpath;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape doneStepOneRect;
        private System.Windows.Forms.Label stepOneLbl;
        private System.Windows.Forms.Label stepTwoLbl;
        private System.Windows.Forms.Label doneStepTwoLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox FilterPath;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape doneStepTwoRect;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ListBox photosPaths;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label browseLbl;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape browseRect;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label numPicsLbl;
        private System.Windows.Forms.Label numLbl;
        private System.Windows.Forms.GroupBox progressFr;
        private System.Windows.Forms.ProgressBar DTprogressBar;
        private System.Windows.Forms.Timer progressBarTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cancelProgressLbl;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label stepThreeLbl;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        protected Microsoft.VisualBasic.PowerPacks.RectangleShape stepThreeRect;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape stepTwoRect;
        protected Microsoft.VisualBasic.PowerPacks.RectangleShape stepOneRect;
        private System.Windows.Forms.CheckBox badContrastChckBox;
        private System.Windows.Forms.CheckBox partitialChckBox;
        private System.Windows.Forms.CheckBox identicalPicsChckBox;
        private System.Windows.Forms.CheckBox similarPicChckBox;
        private System.Windows.Forms.GroupBox bitExactFr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelname;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Label labelLoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.Button createdemo;
        private System.Windows.Forms.Button buttonAbortSelect;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.CheckedListBox MatchesList;
        private System.Windows.Forms.PictureBox PictureResult;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer5;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;



    }
}

