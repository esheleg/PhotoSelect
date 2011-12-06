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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.s1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderslist = new System.Windows.Forms.ListBox();
            this.drivelist = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.s1});
            this.shapeContainer1.Size = new System.Drawing.Size(788, 598);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape2.BackColor = System.Drawing.Color.Maroon;
            this.rectangleShape2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.BorderColor = System.Drawing.SystemColors.Desktop;
            this.rectangleShape2.CornerRadius = 8;
            this.rectangleShape2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangleShape2.FillColor = System.Drawing.Color.White;
            this.rectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape2.Location = new System.Drawing.Point(235, 119);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rectangleShape2.Size = new System.Drawing.Size(207, 50);
            // 
            // s1
            // 
            this.s1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.s1.BackColor = System.Drawing.Color.Maroon;
            this.s1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.s1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.s1.BorderColor = System.Drawing.SystemColors.Desktop;
            this.s1.CornerRadius = 8;
            this.s1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.s1.FillColor = System.Drawing.Color.White;
            this.s1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.s1.Location = new System.Drawing.Point(23, 118);
            this.s1.Name = "s1";
            this.s1.SelectionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.s1.Size = new System.Drawing.Size(207, 50);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.folderslist);
            this.groupBox1.Controls.Add(this.drivelist);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(40, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Miriam", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(419, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Done";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // folderslist
            // 
            this.folderslist.FormattingEnabled = true;
            this.folderslist.Location = new System.Drawing.Point(116, 33);
            this.folderslist.Name = "folderslist";
            this.folderslist.Size = new System.Drawing.Size(175, 173);
            this.folderslist.TabIndex = 4;
            // 
            // drivelist
            // 
            this.drivelist.FormattingEnabled = true;
            this.drivelist.Location = new System.Drawing.Point(25, 33);
            this.drivelist.Name = "drivelist";
            this.drivelist.Size = new System.Drawing.Size(85, 173);
            this.drivelist.TabIndex = 3;
            this.drivelist.SelectedIndexChanged += new System.EventHandler(this.drivelist_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PhotoSelectGui.Properties.Resources.gui_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(788, 598);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoSelect";
            this.Load += new System.EventHandler(this.MainPS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape s1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox folderslist;
        private System.Windows.Forms.ListBox drivelist;
        private System.Windows.Forms.Timer timer1;



    }
}

