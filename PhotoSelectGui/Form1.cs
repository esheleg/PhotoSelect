using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Features;

namespace PhotoSelectGui
{
    public partial class MainPS : Form
    {
        // the image that apears in step one (the chosen photo from list)
        private Image image;

        // array to save all the photos pthes to send to the brain
        string[] filePaths;
        const double FRAME_SPEED = 50;
        
        // the origin of the current frame
        const double FRAME_X = 50;
        const double FRAME_Y = 200;
        
        // for the frames that comes from the left side
        const double LEFT_FRAME_X = -700;
        const double LEFT_FRAME_Y = 200;

       // for the frames that comes from the bottom
        const double BOTTOM_FRAME_X = 50;
        const double BOTTOM_FRAME_Y = 600;
      
        //enum and array of booleans to choose the next step frame
        enum frames { stepOneFr_to_stepTwoFr, stepTwoFr_to_stepOneFr, stepTwoFr_to_progressBarFr, 
            progressBarFr_to_stepTwoFr, progressBarFr_to_bitExactFr };
        bool[] frameShow = new bool[5];

        private void frameShowInit()
        {
            for (int i = 0; i < frameShow.Length; i++)
                frameShow[i] = false;
        }
        
        
        public MainPS()
        {
            InitializeComponent();
            frameShowInit();
            
            image = null;

            PathFrame.Visible = true;
            FilterPath.Visible = false;
            progressFr.Visible = false;
            bitExactFr.Visible = false;
        }

        private void MainPS_Load(object sender, EventArgs e)
        {
            stepOneLbl.BackColor = System.Drawing.Color.AntiqueWhite;
            stepOneRect.FillColor = System.Drawing.Color.AntiqueWhite;

        }

        // timer for the animation - frame change
        private void frameMovementTimer_Tick(object sender, EventArgs e)
        {
            // step one to step two (when clicking Done label)
            if (frameShow[(int)frames.stepOneFr_to_stepTwoFr] == true)
            {
                PathFrame.Location = new Point(PathFrame.Location.X + (int)FRAME_SPEED, PathFrame.Location.Y);
                FilterPath.Location = new Point(FilterPath.Location.X + (int)FRAME_SPEED, FilterPath.Location.Y);

                if (FilterPath.Location.X == FRAME_X)
                {
                    PathFrame.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.stepOneFr_to_stepTwoFr] = false;
                }
            }

            // step two to step one (when clicking step one label)
            if (frameShow[(int)frames.stepTwoFr_to_stepOneFr] == true)
            {
                PathFrame.Location = new Point(PathFrame.Location.X - (int)FRAME_SPEED, PathFrame.Location.Y);
                FilterPath.Location = new Point(FilterPath.Location.X - (int)FRAME_SPEED, FilterPath.Location.Y);

                if (PathFrame.Location.X == FRAME_X)
                {
                    FilterPath.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.stepTwoFr_to_stepOneFr] = false;
                }
            }

            // step two to the progress bar (when clicking Done label in step two) 
            if (frameShow[(int)frames.stepTwoFr_to_progressBarFr] == true)
            {
                FilterPath.Location = new Point(FilterPath.Location.X + (int)FRAME_SPEED, FilterPath.Location.Y);
                progressFr.Location = new Point(progressFr.Location.X, progressFr.Location.Y - (int)FRAME_SPEED);

                if (progressFr.Location.Y == FRAME_Y)
                {
                    FilterPath.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.stepTwoFr_to_progressBarFr] = false;
                }
            }

            // progress bar to step two (when clicking on the Cancel label)
            if (frameShow[(int)frames.progressBarFr_to_stepTwoFr] == true)
            {
                progressFr.Location = new Point(progressFr.Location.X, progressFr.Location.Y + (int)FRAME_SPEED);
                FilterPath.Location = new Point(FilterPath.Location.X - (int)FRAME_SPEED, FilterPath.Location.Y);

                if (FilterPath.Location.X == FRAME_X)
                {
                    progressFr.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.progressBarFr_to_stepTwoFr] = false;
                }
            }

            // progress bar to bit exact frame (when progress bar is done, for now...)
            if (frameShow[(int)frames.progressBarFr_to_bitExactFr] == true)
            {
                progressFr.Location = new Point(progressFr.Location.X, progressFr.Location.Y + (int)FRAME_SPEED);
                bitExactFr.Location = new Point(bitExactFr.Location.X + (int)FRAME_SPEED, bitExactFr.Location.Y);

                if (bitExactFr.Location.X == FRAME_X)
                {
                    progressFr.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.progressBarFr_to_bitExactFr] = false;
                }
            }
        }

        
        //------------------------ buttons------------------------------
        private void doneStepOneLbl_Click(object sender, EventArgs e)
        {

            if (PathFrame.Location.X == FRAME_X) // if PathFrame is the current frame
            {
                frameShow[(int)frames.stepOneFr_to_stepTwoFr] = true; // choose the frame animation
                FilterPath.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
                FilterPath.Visible = true; 

                stepOneLbl.BackColor = System.Drawing.Color.White;
                stepOneRect.FillColor = System.Drawing.Color.White;
                stepTwoLbl.BackColor = System.Drawing.Color.AntiqueWhite;
                stepTwoRect.FillColor = System.Drawing.Color.AntiqueWhite;

                frameMovementTimer.Enabled = true; // turn on the animation
            }
        }

        private void stepOneLbl_Click(object sender, EventArgs e)
        {
            if (FilterPath.Location.X == FRAME_X)
            {
                frameShow[(int)frames.stepTwoFr_to_stepOneFr] = true;
                PathFrame.Visible = true;
                frameMovementTimer.Enabled = true;
            }
        }

        private void doneStepTwoLbl_Click(object sender, EventArgs e)
        {
            if (FilterPath.Location.X == FRAME_X)
            {
                frameShow[(int)frames.stepTwoFr_to_progressBarFr] = true;
                progressFr.Location = new Point((int)BOTTOM_FRAME_X, (int)BOTTOM_FRAME_Y);
                progressFr.Visible = true;
                frameMovementTimer.Enabled = true;
                progressBarTimer.Start();
            }
        }

        private void cancelProgressLbl_Click(object sender, EventArgs e)
        {
            if (progressFr.Location.Y == FRAME_Y)
            {
                frameShow[(int)frames.progressBarFr_to_stepTwoFr] = true;
                FilterPath.Visible = true;
                frameMovementTimer.Enabled = true;
                progressBarTimer.Stop();
                progressBar.Value = 0;
            }
        }
        //----------------------end buttons-----------------------------------


        // put the thumbnail in step two
        private void photosPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (image != null)
                    image.Dispose();
                image = null;
                // Check if textbox has a value
                if (photosPaths.SelectedItem.ToString() != String.Empty)
                    image = Image.FromFile(photosPaths.SelectedItem.ToString());
                // Check if image exists
                if (image != null)
                {
                    pictureBox.Image = image.GetThumbnailImage(300, 200, null, new IntPtr());
                }
            }
            catch
            {
                MessageBox.Show("An error occured");
            }
            pictureBox.Refresh();
        }

        // Browse - to choose the source folder
        private void browseLbl_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textpath.Text = folderBrowserDialog.SelectedPath;
                photosPaths.Items.Clear();
                pictureBox.Image = null;
                filePaths = Directory.GetFiles((string)textpath.Text, "*.jpg", SearchOption.AllDirectories);
                foreach (string filepath in filePaths) //  fills the list of files "filePaths" to send to brain 
                    photosPaths.Items.Add(filepath);
                numLbl.Text = filePaths.Length.ToString(); // number of photos in the folder
            }
        }

        //fills the progress bar, after sending information to the brain, need to recive the percentage of the work that done every timer's tick 
        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(3);
            if (progressBar.Value == progressBar.Maximum)
            {
                progressBarTimer.Stop();
               
                progressBarTimer.Stop();

                // changing form. for now its to the bitmap exact - need to change in future
                if (progressFr.Location.Y == FRAME_Y)
                {
                    frameShow[(int)frames.progressBarFr_to_bitExactFr] = true;
                    bitExactFr.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
                    bitExactFr.Visible = true;
                    frameMovementTimer.Enabled = true;
                    progressBar.Value = 0;
                }

            }
        }

        
        

    }
}
