using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PhotoSelectGui
{
    public partial class MainPS : Form
    {

        double x;
        double y;
        public MainPS()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void MainPS_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
                drivelist.Items.Add(di);
            
            x = groupBox1.Location.X;
            y = groupBox1.Location.Y;
        }

        private void drivelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            folderslist.Items.Clear();
            try
            {
                DriveInfo drive = (DriveInfo)drivelist.SelectedItem;
                foreach (DirectoryInfo dirInfo in drive.RootDirectory.GetDirectories())
                    folderslist.Items.Add(dirInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x=x*1.13;
                groupBox1.Location = new Point((int)x, (int)y);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }


    }
}
