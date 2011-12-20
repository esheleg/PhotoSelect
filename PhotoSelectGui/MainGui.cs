﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Features;
using System.Threading;

namespace PhotoSelectGui
{
    public partial class MainPS : Form
    {
        //basic function to change color for each index we visit, while reset the other colors.
        public void changecolor(int indextab)
        {
            switch (indextab)
            {
                case 1:
                    stepOneLbl.BackColor = Color.BurlyWood;
                    stepOneRect.FillColor = Color.BurlyWood;
                    stepTwoLbl.BackColor = Color.White;
                    stepTwoRect.FillColor = Color.White;
                    stepThreeLbl.BackColor = Color.White;
                    stepThreeRect.FillColor = Color.White;
                    break;
                case 2:
                    stepTwoLbl.BackColor = Color.BurlyWood;
                    stepTwoRect.FillColor = Color.BurlyWood;
                    stepOneLbl.BackColor = Color.White;
                    stepOneRect.FillColor = Color.White;
                    stepThreeLbl.BackColor = Color.White;
                    stepThreeRect.FillColor = Color.White;
                    break;
                case 3:
                    stepThreeLbl.BackColor = Color.BurlyWood;
                    stepThreeRect.FillColor = Color.BurlyWood;
                    stepTwoLbl.BackColor = Color.White;
                    stepTwoRect.FillColor = Color.White;
                    stepOneLbl.BackColor = Color.White;
                    stepOneRect.FillColor = Color.White;
                    break;
                default:
                    break;
            }
        }
        //delete files from bit exact frame(4)
        static bool TryToDelete(string f)
        {
            if (System.IO.File.Exists(f))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(f);
                    return true;
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show("Error");
                    return false;

                }
            }
            return false;
        }
        // the image that apears in step one (the chosen photo from list)
        private Image image;

        // array to save all the photos pthes to send to the brain
        string[] filePaths;
        bool[] featuresArr = new bool[4];
        Task task;
        FeaturesLayer core;

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
        enum frames
        {
            stepOneFr_to_stepTwoFr, stepTwoFr_to_stepOneFr, stepTwoFr_to_progressBarFr,
            progressBarFr_to_stepTwoFr, progressBarFr_to_bitExactFr, stepthreeFr_to_stepOneFr, stepthreeFr_to_stepTwoFr
        };
        bool[] frameShow = new bool[7];

        private void frameShowInit()
        {
            for (int i = 0; i < frameShow.Length; i++)
                frameShow[i] = false;
        }

        private void featuresArrInit()
        {
            for (int i = 0; i < featuresArr.Length; i++)
                featuresArr[i] = false;
        }

        public MainPS()
        {

            InitializeComponent();
            frameShowInit();
            featuresArrInit();

            image = null;

            PathFrame.Visible = true;
            FilterPath.Visible = false;
            progressFr.Visible = false;
            bitExactFr.Visible = false;
            changecolor(1);
        }

        private void MainPS_Load(object sender, EventArgs e)
        {
            //-------arrangeFrames--------
            PathFrame.Location = new Point((int)FRAME_X, (int)FRAME_Y);
            bitExactFr.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
            FilterPath.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
            progressFr.Location = new Point((int)BOTTOM_FRAME_X, (int)BOTTOM_FRAME_Y);

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
                // make the bitExact progressBar no visible
                BitExactProgressLbl.Visible = false;
                BitExactProgressBar.Visible = false;
                
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

            // bitExact frame to pathFrame(stepOne) frame (when when clicking step One button)
            if (frameShow[(int)frames.stepthreeFr_to_stepOneFr] == true)
            {
                PathFrame.Location = new Point(PathFrame.Location.X - (int)FRAME_SPEED, PathFrame.Location.Y);
                bitExactFr.Location = new Point(bitExactFr.Location.X - (int)FRAME_SPEED, bitExactFr.Location.Y);

                if (PathFrame.Location.X == FRAME_X)
                {
                    bitExactFr.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.stepthreeFr_to_stepOneFr] = false;
                }
            }

            // bitExact frame to step two frame (when clicking step Two button)
            if (frameShow[(int)frames.stepthreeFr_to_stepTwoFr] == true)
            {
                FilterPath.Location = new Point(FilterPath.Location.X - (int)FRAME_SPEED, FilterPath.Location.Y);
                bitExactFr.Location = new Point(bitExactFr.Location.X - (int)FRAME_SPEED, bitExactFr.Location.Y);

                if (FilterPath.Location.X == FRAME_X)
                {
                    bitExactFr.Visible = false;
                    frameMovementTimer.Enabled = false;
                    frameShow[(int)frames.stepthreeFr_to_stepTwoFr] = false;
                }
            }
        }


        //------------------------ buttons------------------------------
        private void doneStepOneLbl_Click(object sender, EventArgs e)
        {

            if (photosPaths.Items.Count > 0)
            {
                if (PathFrame.Location.X == FRAME_X) // if PathFrame is the current frame
                {
                    frameShow[(int)frames.stepOneFr_to_stepTwoFr] = true; // choose the frame animation
                    FilterPath.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
                    FilterPath.Visible = true;
                    frameMovementTimer.Enabled = true; // turn on the animation
                    changecolor(2);
                }

            }
            else MessageBox.Show("לא נבחרה תיקייה המכילה תמונות");
        }

        private void stepOneLbl_Click(object sender, EventArgs e)
        {
            if (FilterPath.Location.X == FRAME_X)
            {
                frameShow[(int)frames.stepTwoFr_to_stepOneFr] = true;
                PathFrame.Visible = true;
                frameMovementTimer.Enabled = true;
                changecolor(1);
            }
            if (bitExactFr.Location.X == FRAME_X)
            {
                frameShow[(int)frames.stepthreeFr_to_stepOneFr] = true;
                FilterPath.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
                PathFrame.Visible = true;
                frameMovementTimer.Enabled = true;
                changecolor(1);
            }
        }

        private void doneStepTwoLbl_Click(object sender, EventArgs e)
        {
            bool checks = false;
            for (int i = 0; i < featuresArr.Length; i++)
                if (featuresArr[i] == true)
                    checks = true;
            if (checks == true)
            {
                task = new Task(filePaths.ToList(), featuresArr);
                core = new FeaturesLayer(ref task);
                Thread t = new Thread(core.loadImages);
                t.Start();

                if (FilterPath.Location.X == FRAME_X)
                {
                    frameShow[(int)frames.stepTwoFr_to_progressBarFr] = true;
                    progressFr.Location = new Point((int)BOTTOM_FRAME_X, (int)BOTTOM_FRAME_Y);
                    progressFr.Visible = true;
                    frameMovementTimer.Enabled = true;
                    progressBarTimer.Start();
                    changecolor(3);
                }
            }
            else MessageBox.Show("חובה לבחור באפשרות אחת לפחות");
        }

        private void cancelProgressLbl_Click(object sender, EventArgs e)
        {
            // ----------daniel need to do something about it----------

            /*if (progressFr.Location.Y == FRAME_Y)
            {
                frameShow[(int)frames.progressBarFr_to_stepTwoFr] = true;
                FilterPath.Visible = true;
                frameMovementTimer.Enabled = true;
                progressBarTimer.Stop();
                DTprogressBar.Value = 0;
            }*/
        }

        private void stepTwoLbl_Click(object sender, EventArgs e)
        {
            if (bitExactFr.Location.X == FRAME_X)
            {
                frameShow[(int)frames.stepthreeFr_to_stepTwoFr] = true;
                FilterPath.Visible = true;
                frameMovementTimer.Enabled = true;
                changecolor(2);
            }

            if (PathFrame.Location.X == FRAME_X)
            {
                // if PathFrame is the current frame
                if (photosPaths.Items.Count > 0)
                {
                    frameShow[(int)frames.stepOneFr_to_stepTwoFr] = true; // choose the frame animation
                    FilterPath.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
                    FilterPath.Visible = true;
                    frameMovementTimer.Enabled = true; // turn on the animation
                    changecolor(2);
                }
                else MessageBox.Show("לא נבחרה תיקייה המכילה תמונות");
            }

        }

        private void stepThreeLbl_Click(object sender, EventArgs e)
        {

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
                if (filePaths.Length > 0)
                    foreach (string filepath in filePaths) //  fills the list of files "filePaths" to send to brain 
                        photosPaths.Items.Add(filepath);
                else MessageBox.Show("התיקייה אותה בחרת אינה מכילה תמונות");
                numLbl.Text = filePaths.Length.ToString(); // number of photos in the folder
            }
        }

        //fills the progress bar, after sending information to the brain, need to recive the percentage of the work that done every timer's tick 
        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            DBprogressBar.Value = core.LoadingImagesStatus;
            if (DBprogressBar.Value == DBprogressBar.Maximum)
            {
                progressBarTimer.Stop();
                BitExactProgressLbl.Visible = true;
                BitExactProgressBar.Visible = true;
                Thread run = new Thread(core.run);
                run.Start();
                bitExactProgressTimer.Start();
            }
        }

        private void bitExactProgressTimer_Tick(object sender, EventArgs e)
        {
            BitExactProgressBar.Value = core.RunStatus;
            if (BitExactProgressBar.Value == BitExactProgressBar.Maximum)
            {
                progressBarTimer.Stop();

                // changing form. for now its to the bitmap exact - need to change in future
                if (progressFr.Location.Y == FRAME_Y)
                {
                    frameShow[(int)frames.progressBarFr_to_bitExactFr] = true;
                    bitExactFr.Location = new Point((int)LEFT_FRAME_X, (int)LEFT_FRAME_Y);
                    bitExactFr.Visible = true;
                    frameMovementTimer.Enabled = true;
                    DBprogressBar.Value = 0;
                }
            }
        }

        //---------------Check boxes for features select-----------------------
        private void similarPicChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (similarPicChckBox.Checked == true)
                featuresArr[(int)Feature.SIMILARITY] = true;
            else featuresArr[(int)Feature.SIMILARITY] = false;
        }

        private void badContrastChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (badContrastChckBox.Checked == true)
                featuresArr[(int)Feature.BAD_CONTRAST] = true;
            else featuresArr[(int)Feature.BAD_CONTRAST] = false;
        }

        private void partitialChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (partitialChckBox.Checked == true)
                featuresArr[(int)Feature.PARTIAL_BLOCKAGE] = true;
            else featuresArr[(int)Feature.PARTIAL_BLOCKAGE] = false;
        }

        private void identicalPicsChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (identicalPicsChckBox.Checked == true)
                featuresArr[(int)Feature.BIT_EXACT] = true;
            else featuresArr[(int)Feature.BIT_EXACT] = false;
        }

        private void DTprogressBar_Click(object sender, EventArgs e)
        {

        }

        private void bitExactFr_Enter(object sender, EventArgs e)
        {

        }


        //creating a demo to check functions for frame 4
                   // foreach (string filepath in filePaths) //  fills the list of files "filePaths" to send to brain 
               // MatchesList.Items.Add(filepath);
        private void createdemo_Click_1(object sender, EventArgs e)
        {
            int bitXCurrent=0; //current head to show on bitexact
            MatchesList.Items.Clear();
            if(core.Res.BitExact.Matches.Count!=0){
                MessageBox.Show("נמצאו תוצאות");
                for (int i = 0; i < core.Res.BitExact.Matches[bitXCurrent].Count; i++)
                {
                    MatchesList.Items.Add(core.Res.BitExact.Matches[bitXCurrent][i]);
                }

            }else
                MessageBox.Show("לא נמצאו תמונות דומות");
        }
        //deleting the selected items from checkboxlist
        //in the fouture will not delete- will save in "todelete" list
        private void buttonDeleteSelected_Click_1(object sender, EventArgs e)
        {
            //dispose all memmory in use
            PictureResult.Image = null;
            pictureBox.Image = null;
            image.Dispose();
            //send to delete function if checked
            for (int i = 0; i < MatchesList.Items.Count; i++)
            {
                if (MatchesList.GetItemChecked(i))
                {

                    TryToDelete(MatchesList.Items[i].ToString());
                }
            }

        }
        //un select all list

        private void buttonAbortSelect_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < MatchesList.Items.Count; i++)
                MatchesList.SetItemChecked(i, false);
        }
        //select all list
        private void buttonSelectAll_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < MatchesList.Items.Count; i++)
                MatchesList.SetItemChecked(i, true);
        }
        //evry click on list will appear in pictureresult

        private void MatchesList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (image != null)
                    image.Dispose();
                image = null;
                // Check if textbox has a value
                if (MatchesList.SelectedItem.ToString() != String.Empty)
                    image = Image.FromFile(MatchesList.SelectedItem.ToString());
                // Check if image exists
                if (image != null)
                {
                    PictureResult.Image = image.GetThumbnailImage(168, 148, null, new IntPtr());
                    labelLoc.Text = MatchesList.SelectedItem.ToString();
                }
            }
            catch
            {
                MessageBox.Show("An error occured");
            }
            PictureResult.Refresh();

        }
        //demo button to delete all list
        private void button1_Click_1(object sender, EventArgs e)
        {
            MatchesList.Items.Clear();
        }

       






    }
}