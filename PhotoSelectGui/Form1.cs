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
        Features.Task t;

        // saves groupBox1 exit sliding movement position in each tick
        double x;
        double y;
        public MainPS()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {
            int x; // TODO delete me- just a commit check
        }

        private void MainPS_Load(object sender, EventArgs e)
        {
            // read all drives info and add their 'name' to driveList(ListBox)
            foreach (DriveInfo di in DriveInfo.GetDrives())
                drivelist.Items.Add(di);
            
            // saves start position for "DONE" movement
            x = groupBox1.Location.X;
            y = groupBox1.Location.Y;
        }

        private void drivelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            folderslist.Items.Clear();
            try
            {
                // display drive root folder content (folders names)
                DriveInfo drive = (DriveInfo)drivelist.SelectedItem;
                foreach (DirectoryInfo dirInfo in drive.RootDirectory.GetDirectories())
                    folderslist.Items.Add(dirInfo);
            }
            catch (Exception ex)
            {
                // possible reason - Selected drive is the DVD Drive
                folderslist.Items.Add(ex.Message);                                
            }
        }

        // the delta move for each tick for groupBox1
        private void timer1_Tick(object sender, EventArgs e)
        {
            x=x*1.13;
            groupBox1.Location = new Point((int)x, (int)y);
        }

        // DONE Buttom on groupBox1
        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

    }
}
